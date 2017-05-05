using MVCDemo.Properties;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Item
    {
        [Display(Name = "Id")]
        [Key]
        public virtual int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "NameIsRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "NameIsTooLong")]
        [MinLength(2, ErrorMessageResourceName = "NameIsNotLongEnough", ErrorMessageResourceType = typeof(ErrorMessages))]
        // [MinLength(1, ErrorMessage ="{0} not long enough.", ErrorMessageResourceName = "NameNotLongEnough", ErrorMessageResourceType = typeof(ErrorMessages))]
        public virtual string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "DescriptionIsRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "DescriptionIsTooLong")]
        [MinLength(3, ErrorMessageResourceName = "DescriptionIsNotLongEnough", ErrorMessageResourceType = typeof(ErrorMessages))]
        public virtual string Description { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "TypeIsRequired")]
        public virtual int ItemTypeId { get; set; }
        [Display(Name = "Type")]
        public virtual ItemType ItemType { get; set; }

    }
}