using Api.ServiceModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceModel.Models
{
    [DataContract]
    public class RequestMetadata
    {
        [RequiredItem]
        [DataMember(Name = "requestid")]
        public string RequestId
        {
            get; set;
        }
    }
}
