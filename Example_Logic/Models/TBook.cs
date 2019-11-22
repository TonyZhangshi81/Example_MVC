using System.ComponentModel.DataAnnotations;

namespace Example_Logic.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TBook
    {
        /// <summary>
        /// 
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Description is required")]
        [MinLength(10)]
        [MaxLength(100)]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ImgUrl { get; set; }
    }
}
