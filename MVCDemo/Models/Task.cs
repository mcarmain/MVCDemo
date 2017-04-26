using MVCDemo.Properties;
using System.ComponentModel.DataAnnotations;
using MVCDemo.Models;

namespace MVCDemo.Models
{
    public class Task
    {
        [Display(Name = "Id")]
        [Key]
        public virtual int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "NameIsRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "NameIsTooLong")]
        [MinLength(1, ErrorMessageResourceName = "NameIsNotLongEnough", ErrorMessageResourceType = typeof(ErrorMessages))]
        public virtual string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "DescriptionIsRequired")]
        [StringLength(1024, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "DescriptionIsTooLong")]
        [MinLength(5, ErrorMessageResourceName = "DescriptionIsNotLongEnough", ErrorMessageResourceType = typeof(ErrorMessages))]
        public virtual string Description { get; set; }

        [Display(Name = "Points")]
        public virtual int Points { get; set; }

        [Display(Name = "Artifacts")]
        [StringLength(1024, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "ArtifactsIsTooLong")]
        public virtual string Artifacts { get; set; }

        [Display(Name = "Owner")]
        [StringLength(100, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "OwnerIsTooLong")]
        public virtual string Owner { get; set; }


        [Display(Name = "Dependencies")]
        [StringLength(1024, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "DependenciesIsTooLong")]
        public virtual string Dependencies { get; set; }

        [Display(Name = "Complete")]
        public virtual bool Complete { get; set; }

    }
}