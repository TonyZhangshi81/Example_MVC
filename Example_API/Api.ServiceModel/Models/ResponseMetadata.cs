using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceModel.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ResponseMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "status", Order = 0)]
        public int Status
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "version", Order = 1)]
        public string Version
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "timestamp", Order = 2)]
        public string Timestamp
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "requestId", Order = 3)]
        public string RequestId
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "messages", Order = 4)]
        public List<string> Messages
        {
            get; set;
        }
    }
}
