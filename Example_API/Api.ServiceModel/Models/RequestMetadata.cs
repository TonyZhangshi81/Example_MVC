using Api.ServiceModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Api.ServiceModel.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class RequestMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        [RequiredItem]
        [GuidType]
        [DataMember(Name = "requestid")]
        public string RequestId
        {
            get; set;
        }
    }
}
