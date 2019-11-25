using System.Runtime.Serialization;

namespace Example_Logic.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ApiGetBookWithIdType
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public BookInfo GetBookResult { get; set; }
    }
}
