using Api.ServiceModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Api.ServiceModel.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ApiBookWithIdRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "id")]
        [RequiredItem]
        public string ID { get; set; }
    }
}
