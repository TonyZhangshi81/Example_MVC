using System.Runtime.Serialization;

namespace Example_Logic.Models
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
