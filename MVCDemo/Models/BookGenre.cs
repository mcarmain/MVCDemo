using MVCDemo.Properties;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class BookGenre
    {
        [Display(Name = "Id")]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "NameIsRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "NameIsTooLong")]
        [MinLength(2, ErrorMessageResourceName = "NameIsNotLongEnough", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Name { get; set; }
    }
}