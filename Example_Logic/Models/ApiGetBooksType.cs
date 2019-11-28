using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Example_Logic.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ApiGetBooksType
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Example_Models.Entities.Book> GetBooksResult { get; set; }
    }
}
