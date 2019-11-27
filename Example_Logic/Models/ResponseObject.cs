using System.Runtime.Serialization;

namespace Example_Logic.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TMetadata"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    [DataContract]
    public class ResponseObject<TMetadata, TResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "metadata")]
        public TMetadata Metadata { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "response")]
        public TResponse Response { get; set; }
    }
}
