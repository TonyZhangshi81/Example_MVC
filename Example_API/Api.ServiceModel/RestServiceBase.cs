using Api.ServiceModel.DataAnnotations;
using Example.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace Api.ServiceModel
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class RestServiceBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        protected bool TryValidate(object instance, out List<string> errors)
        {
            DataAnnotationsValidator dataAnnotationsValidator = new DataAnnotationsValidator();
            List<ValidationResult> list = new List<ValidationResult>();
            if (!dataAnnotationsValidator.TryValidateObjectRecursive(instance, list))
            {
                errors = list.Select<ValidationResult, string>(d => d.ErrorMessage).ToList();
                return false;
            }
            errors = new List<string>();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        protected Message CreateMessage(object value, int statusCode = 200)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = (HttpStatusCode)statusCode;
            HttpContext.Current.Items.Add("ResponseType", (statusCode >= 400) ? "Error" : "Normal");
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(value.GetType());
                dataContractJsonSerializer.WriteObject(memoryStream, value);
                UTF8Encoding uTF8Encoding = new UTF8Encoding(GetWebApiResponseUtf8Bom());
                return WebOperationContext.Current.CreateTextResponse(uTF8Encoding.GetString(memoryStream.ToArray()), "application/json; charset=utf-8", uTF8Encoding);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool GetWebApiResponseUtf8Bom()
        {
            string value = ConfigurationManager.AppSettings["WebApiResponseUtf8Bom"];
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            ExtBooleanConverter booleanConverter = new ExtBooleanConverter();
            return (bool)booleanConverter.ConvertFrom(value);
        }
    }
}
