using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Example_MVC
{
	// メモ: [リファクター] メニューの [名前の変更] コマンドを使用すると、コードと config ファイルの両方で同時にインターフェイス名 "IService" を変更できます。
	[ServiceContract]
	public interface IBookService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(UriTemplate = "/GetCount", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		int GetCount(int id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(UriTemplate = "/GetData", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
		BookInfo GetData(int id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="composite"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(UriTemplate = "/Update", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		int UpdateMoshikomiInfo(BookInfo info);
	}

	// サービス操作に複合型を追加するには、以下のサンプルに示すようにデータ コントラクトを使用します。
	/// <summary>
	/// 
	/// </summary>
	[DataContract]
	public class BookInfo
	{
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int ID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Description { get; set; }
	}
}