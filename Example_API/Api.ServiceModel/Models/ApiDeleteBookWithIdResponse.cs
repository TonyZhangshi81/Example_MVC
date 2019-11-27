using System.Runtime.Serialization;

namespace Api.ServiceModel.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ApiDeleteBookWithIdResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "result")]
        public string Result { get; set; }
    }
}
