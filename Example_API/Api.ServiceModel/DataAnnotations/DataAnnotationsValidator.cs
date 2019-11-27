using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Api.ServiceModel.DataAnnotations
{
    public class DataAnnotationsValidator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="results"></param>
        /// <param name="validationContextItems"></param>
        /// <returns></returns>
        public bool TryValidateObject(object obj, ICollection<ValidationResult> results, IDictionary<object, object> validationContextItems = null)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj, null, validationContextItems), results, validateAllProperties: true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="results"></param>
        /// <param name="validationContextItems"></param>
        /// <returns></returns>
        public bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, IDictionary<object, object> validationContextItems = null)
        {
            return TryValidateObjectRecursive(obj, results, new HashSet<object>(), validationContextItems);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="o"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private object GetPropertyValue(object o, string propertyName)
        {
            object result = string.Empty;
            PropertyInfo property = o.GetType().GetProperty(propertyName);
            if (property != null)
            {
                result = property.GetValue(o, null);
            }
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="results"></param>
        /// <param name="validatedObjects"></param>
        /// <param name="validationContextItems"></param>
        /// <returns></returns>
        private bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, ISet<object> validatedObjects, IDictionary<object, object> validationContextItems = null)
        {
            if (validatedObjects.Contains(obj))
            {
                return true;
            }
            validatedObjects.Add(obj);
            bool result = TryValidateObject(obj, results, validationContextItems);
            List<PropertyInfo> list = (from prop in obj.GetType().GetProperties()
                                       where prop.CanRead && prop.GetIndexParameters().Length == 0
                                       select prop).ToList();
            foreach (PropertyInfo item in list)
            {
                if (!(item.PropertyType == typeof(string)) && !item.PropertyType.IsValueType)
                {
                    object propertyValue = GetPropertyValue(obj, item.Name);
                    if (propertyValue != null)
                    {
                        IEnumerable enumerable;
                        if ((enumerable = (propertyValue as IEnumerable)) != null)
                        {
                            foreach (object item2 in enumerable)
                            {
                                if (item2 != null)
                                {
                                    List<ValidationResult> list2 = new List<ValidationResult>();
                                    if (!TryValidateObjectRecursive(item2, list2, validatedObjects, validationContextItems))
                                    {
                                        result = false;
                                        foreach (ValidationResult item3 in list2)
                                        {
                                            PropertyInfo property2 = item;
                                            results.Add(new ValidationResult(item3.ErrorMessage, item3.MemberNames.Select((string x) => property2.Name + "." + x)));
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            List<ValidationResult> list3 = new List<ValidationResult>();
                            if (!TryValidateObjectRecursive(propertyValue, list3, validatedObjects, validationContextItems))
                            {
                                result = false;
                                foreach (ValidationResult item4 in list3)
                                {
                                    PropertyInfo property = item;
                                    results.Add(new ValidationResult(item4.ErrorMessage, item4.MemberNames.Select((string x) => property.Name + "." + x)));
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
