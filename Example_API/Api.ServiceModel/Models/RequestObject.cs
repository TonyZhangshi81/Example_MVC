using Api.ServiceModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Api.ServiceModel.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TMetadata"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    [DataContract]
    public class RequestObject<TMetadata, TRequest>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="request"></param>
        public RequestObject(TMetadata metadata, TRequest request)
        {
            Metadata = metadata;
            Request = request;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "metadata")]
        [RequiredItem]
        public TMetadata Metadata { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "request")]
        public TRequest Request { get; set; }
    }
}
