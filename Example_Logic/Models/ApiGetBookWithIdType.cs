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
        public Example_Models.Entities.Book GetBookResult { get; set; }
    }
}
