using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Example_Models.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Book
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ID")]
        public string ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(100)]
        [DataMember(Name = "Description")]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ImgUrl")]
        public string ImgUrl { get; set; }
    }
}
