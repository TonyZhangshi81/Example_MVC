// Isid.BankR.Core.Web.UI.DynamicJson
#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;

/// <summary>
///
/// </summary>
/// <remarks>
/// ベースとなるDynamicJsonクラスに対して行った変更点は以下の通り。
/// <list type="bullet">
/// <item>classにpartialを付与</item>
/// <item>namespaceの変更</item>
/// <item>ビルド時に警告がでないようコメントを付与</item>
/// <item>CreateJsonNodeメソッド内で、number時に、型がenumだったらint32に変換してから返すように修正</item>
/// </list>
/// </remarks>
/// <summary>
/// DynamicJsonクラスに対する独自メソッドを追加します。
/// </summary>
public class DynamicJson : DynamicObject
{
	/// <summary>
	///
	/// </summary>
	private enum JsonType
	{
		@string,
		number,
		boolean,
		@object,
		array,
		@null
	}

	private readonly XElement _xml;

	private readonly JsonType _jsonType;

	/// <summary>
	///
	/// </summary>
	public bool IsObject => _jsonType == JsonType.@object;

	/// <summary>
	///
	/// </summary>
	public bool IsArray => _jsonType == JsonType.array;

	/// <summary>
	///
	/// </summary>
	/// <param name="json"></param>
	/// <returns></returns>
	public static dynamic Parse(string json)
	{
		return Parse(json, Encoding.Unicode);
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="json"></param>
	/// <param name="encoding"></param>
	/// <returns></returns>
	public static dynamic Parse(string json, Encoding encoding)
	{
		using (XmlDictionaryReader reader = JsonReaderWriterFactory.CreateJsonReader(encoding.GetBytes(json), XmlDictionaryReaderQuotas.Max))
		{
			return ToValue(XElement.Load(reader));
		}
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="stream"></param>
	/// <returns></returns>
	public static dynamic Parse(Stream stream)
	{
		using (XmlDictionaryReader reader = JsonReaderWriterFactory.CreateJsonReader(stream, XmlDictionaryReaderQuotas.Max))
		{
			return ToValue(XElement.Load(reader));
		}
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="stream"></param>
	/// <param name="encoding"></param>
	/// <returns></returns>
	public static dynamic Parse(Stream stream, Encoding encoding)
	{
		using (XmlDictionaryReader reader = JsonReaderWriterFactory.CreateJsonReader(stream, encoding, XmlDictionaryReaderQuotas.Max, delegate
		{
		}))
		{
			return ToValue(XElement.Load(reader));
		}
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	public static string Serialize(object obj)
	{
		return CreateJsonString(new XStreamingElement("root", CreateTypeAttr(GetJsonType(obj)), CreateJsonNode(obj)));
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="element"></param>
	/// <returns></returns>
	private static dynamic ToValue(XElement element)
	{
		JsonType jsonType = (JsonType)Enum.Parse(typeof(JsonType), element.Attribute("type").Value);
		switch (jsonType)
		{
		case JsonType.boolean:
			return (bool)element;
		case JsonType.number:
			return (double)element;
		case JsonType.@string:
			return (string)element;
		case JsonType.@object:
		case JsonType.array:
			return new DynamicJson(element, jsonType);
		default:
			return null;
		}
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	private static JsonType GetJsonType(object obj)
	{
		if (obj == null)
		{
			return JsonType.@null;
		}
		switch (Type.GetTypeCode(obj.GetType()))
		{
		case TypeCode.Boolean:
			return JsonType.boolean;
		case TypeCode.Char:
		case TypeCode.DateTime:
		case TypeCode.String:
			return JsonType.@string;
		case TypeCode.SByte:
		case TypeCode.Byte:
		case TypeCode.Int16:
		case TypeCode.UInt16:
		case TypeCode.Int32:
		case TypeCode.UInt32:
		case TypeCode.Int64:
		case TypeCode.UInt64:
		case TypeCode.Single:
		case TypeCode.Double:
		case TypeCode.Decimal:
			return JsonType.number;
		case TypeCode.Object:
			return (obj is IEnumerable) ? JsonType.array : JsonType.@object;
		default:
			return JsonType.@null;
		}
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	private static XAttribute CreateTypeAttr(JsonType type)
	{
		return new XAttribute("type", type.ToString());
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	private static object CreateJsonNode(object obj)
	{
		switch (GetJsonType(obj))
		{
		case JsonType.@string:
		case JsonType.number:
			return obj.GetType().IsEnum ? ((object)(int)obj) : obj;
		case JsonType.boolean:
			return obj.ToString().ToLower();
		case JsonType.@object:
			return CreateXObject(obj);
		case JsonType.array:
			return CreateXArray(obj as IEnumerable);
		default:
			return null;
		}
	}

	/// <summary>
	///
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="obj"></param>
	/// <returns></returns>
	private static IEnumerable<XStreamingElement> CreateXArray<T>(T obj) where T : IEnumerable
	{
		return from object o in obj
			select new XStreamingElement("item", CreateTypeAttr(GetJsonType(o)), CreateJsonNode(o));
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	private static IEnumerable<XStreamingElement> CreateXObject(object obj)
	{
		return from pi in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
			select new
			{
				Name = pi.Name,
				Value = pi.GetValue(obj, null)
			} into a
			select new XStreamingElement(a.Name, CreateTypeAttr(GetJsonType(a.Value)), CreateJsonNode(a.Value));
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="element"></param>
	/// <returns></returns>
	private static string CreateJsonString(XStreamingElement element)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			using (XmlDictionaryWriter xmlDictionaryWriter = JsonReaderWriterFactory.CreateJsonWriter(memoryStream, Encoding.Unicode))
			{
				element.WriteTo(xmlDictionaryWriter);
				xmlDictionaryWriter.Flush();
				return Encoding.Unicode.GetString(memoryStream.ToArray());
			}
		}
	}

	/// <summary>
	///
	/// </summary>
	public DynamicJson()
	{
		_xml = new XElement("root", CreateTypeAttr(JsonType.@object));
		_jsonType = JsonType.@object;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="element"></param>
	/// <param name="type"></param>
	private DynamicJson(XElement element, JsonType type)
	{
		Debug.Assert(type == JsonType.array || type == JsonType.@object);
		_xml = element;
		_jsonType = type;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public bool IsDefined(string name)
	{
		return IsObject && _xml.Element(name) != null;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public bool IsDefined(int index)
	{
		return IsArray && _xml.Elements().ElementAtOrDefault(index) != null;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public bool Delete(string name)
	{
		XElement xElement = _xml.Element(name);
		if (xElement != null)
		{
			xElement.Remove();
			return true;
		}
		return false;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public bool Delete(int index)
	{
		XElement xElement = _xml.Elements().ElementAtOrDefault(index);
		if (xElement != null)
		{
			xElement.Remove();
			return true;
		}
		return false;
	}

	/// <summary>
	///
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public T Deserialize<T>()
	{
		return (T)Deserialize(typeof(T));
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public object Deserialize(Type type)
	{
		return IsArray ? DeserializeArray(type) : DeserializeObject(type);
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="element"></param>
	/// <param name="elementType"></param>
	/// <returns></returns>
	private dynamic DeserializeValue(XElement element, Type elementType)
	{
		dynamic val = ToValue(element);
		if (val is DynamicJson)
		{
			val = ((DynamicJson)val).Deserialize(elementType);
		}
		return Convert.ChangeType(val, elementType);
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="targetType"></param>
	/// <returns></returns>
	private object DeserializeObject(Type targetType)
	{
		object obj = Activator.CreateInstance(targetType);
		Dictionary<string, PropertyInfo> dictionary = (from p in targetType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
			where p.CanWrite
			select p).ToDictionary((PropertyInfo pi) => pi.Name, (PropertyInfo pi) => pi);
		foreach (XElement item in _xml.Elements())
		{
			if (dictionary.TryGetValue(item.Name.LocalName, out PropertyInfo value))
			{
				dynamic val = DeserializeValue(item, value.PropertyType);
				value.SetValue(obj, val, null);
			}
		}
		return obj;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="targetType"></param>
	/// <returns></returns>
	private object DeserializeArray(Type targetType)
	{
		if (targetType.IsArray)
		{
			Type elementType = targetType.GetElementType();
			dynamic val = Array.CreateInstance(elementType, _xml.Elements().Count());
			int num = 0;
			foreach (XElement item in _xml.Elements())
			{
				val[num++] = DeserializeValue(item, elementType);
			}
			return val;
		}
		Type elementType2 = targetType.GetGenericArguments()[0];
		dynamic val2 = Activator.CreateInstance(targetType);
		foreach (XElement item2 in _xml.Elements())
		{
			val2.Add(DeserializeValue(item2, elementType2));
		}
		return val2;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="binder"></param>
	/// <param name="args"></param>
	/// <param name="result"></param>
	/// <returns></returns>
	public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
	{
		result = (IsArray ? Delete((int)args[0]) : Delete((string)args[0]));
		return true;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="binder"></param>
	/// <param name="args"></param>
	/// <param name="result"></param>
	/// <returns></returns>
	public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
	{
		if (args.Length != 0)
		{
			result = null;
			return false;
		}
		result = IsDefined(binder.Name);
		return true;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="binder"></param>
	/// <param name="result"></param>
	/// <returns></returns>
	public override bool TryConvert(ConvertBinder binder, out object result)
	{
		if (binder.Type == typeof(IEnumerable) || binder.Type == typeof(object[]))
		{
			IEnumerable<object> enumerable = IsArray ? _xml.Elements().Select((Func<XElement, object>)((XElement x) => ToValue(x))) : _xml.Elements().Select((Func<XElement, object>)((XElement x) => new KeyValuePair<string, object>(x.Name.LocalName, ToValue(x))));
			IEnumerable<object> enumerable2;
			if (!(binder.Type == typeof(object[])))
			{
				enumerable2 = enumerable;
			}
			else
			{
				IEnumerable<object> enumerable3 = enumerable.ToArray();
				enumerable2 = enumerable3;
			}
			result = enumerable2;
		}
		else
		{
			result = Deserialize(binder.Type);
		}
		return true;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="element"></param>
	/// <param name="result"></param>
	/// <returns></returns>
	private bool TryGet(XElement element, out object result)
	{
		if (element == null)
		{
			result = null;
			return false;
		}
		result = ToValue(element);
		return true;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="binder"></param>
	/// <param name="indexes"></param>
	/// <param name="result"></param>
	/// <returns></returns>
	public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
	{
		return IsArray ? TryGet(_xml.Elements().ElementAtOrDefault((int)indexes[0]), out result) : TryGet(_xml.Element((string)indexes[0]), out result);
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="binder"></param>
	/// <param name="result"></param>
	/// <returns></returns>
	public override bool TryGetMember(GetMemberBinder binder, out object result)
	{
		return IsArray ? TryGet(_xml.Elements().ElementAtOrDefault(int.Parse(binder.Name)), out result) : TryGet(_xml.Element(binder.Name), out result);
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="name"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	private bool TrySet(string name, object value)
	{
		JsonType jsonType = GetJsonType(value);
		XElement xElement = _xml.Element(name);
		if (xElement == null)
		{
			_xml.Add(new XElement(name, CreateTypeAttr(jsonType), CreateJsonNode(value)));
		}
		else
		{
			xElement.Attribute("type").Value = jsonType.ToString();
			xElement.ReplaceNodes(CreateJsonNode(value));
		}
		return true;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="index"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	private bool TrySet(int index, object value)
	{
		JsonType jsonType = GetJsonType(value);
		XElement xElement = _xml.Elements().ElementAtOrDefault(index);
		if (xElement == null)
		{
			_xml.Add(new XElement("item", CreateTypeAttr(jsonType), CreateJsonNode(value)));
		}
		else
		{
			xElement.Attribute("type").Value = jsonType.ToString();
			xElement.ReplaceNodes(CreateJsonNode(value));
		}
		return true;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="binder"></param>
	/// <param name="indexes"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
	{
		return IsArray ? TrySet((int)indexes[0], value) : TrySet((string)indexes[0], value);
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="binder"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public override bool TrySetMember(SetMemberBinder binder, object value)
	{
		return IsArray ? TrySet(int.Parse(binder.Name), value) : TrySet(binder.Name, value);
	}

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
	public override IEnumerable<string> GetDynamicMemberNames()
	{
		return IsArray ? _xml.Elements().Select((XElement x, int i) => i.ToString()) : (from x in _xml.Elements()
			select x.Name.LocalName);
	}

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		foreach (XElement item in from x in _xml.Descendants()
			where x.Attribute("type").Value == "null"
			select x)
		{
			item.RemoveNodes();
		}
		return CreateJsonString(new XStreamingElement("root", CreateTypeAttr(_jsonType), _xml.Elements()));
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="name"></param>
	/// <param name="result"></param>
	/// <returns></returns>
	public bool TryGet(string name, out object result)
	{
		result = null;
		XElement xElement = _xml.Element(name);
		return xElement != null && TryGet(xElement, out result);
	}
}
