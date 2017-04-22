using MVCDemo.Properties;
using System.ComponentModel.DataAnnotations;
using MVCDemo.Models;

namespace MVCDemo.Models
{
    public class Book
    {
        [Key]
        [Display(Name = "Id")]
        public virtual int Id { get; set; }

        [Display(Name = "Title")]
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
        public virtual int BookTypeId { get; set; }
        [Display(Name = "Type")]
        public virtual BookType BookType { get; set; }

        [Display(Name = "Publisher")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "PublisherIsRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "PublisherIsTooLong")]
        [MinLength(3, ErrorMessageResourceName = "PublisherIsNotLongEnough", ErrorMessageResourceType = typeof(ErrorMessages))]
        public virtual string Publisher { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "AuthorIsRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "AuthorIsTooLong")]
        [MinLength(3, ErrorMessageResourceName = "AuthorIsNotLongEnough", ErrorMessageResourceType = typeof(ErrorMessages))]
        public virtual string Author { get; set; }
    }  
}