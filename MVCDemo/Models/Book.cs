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
        public virtual string Title { get; set; }

        [Display(Name = "Summary")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "SummaryIsRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "SummaryIsTooLong")]
        [MinLength(3, ErrorMessageResourceName = "SummaryIsNotLongEnough", ErrorMessageResourceType = typeof(ErrorMessages))]
        public virtual string Summary { get; set; }

    
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

        [Display(Name = "Genre")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "GenreIsRequired")]
        public virtual int BookGenreId { get; set; }
        [Display(Name = "Genre")]
        public virtual BookGenre BookGenre { get; set; }
    }  
}