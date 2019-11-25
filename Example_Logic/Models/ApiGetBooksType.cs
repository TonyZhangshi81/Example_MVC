using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public List<BookInfo> GetBooksResult { get; set; }
    }
}
