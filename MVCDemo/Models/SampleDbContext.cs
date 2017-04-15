
namespace MVCDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using MVCDemo.Properties;

    public class SampleDbContext : DbContext
    {
        // Your context has been configured to use a 'SampleDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MVCDemo.Models.SampleDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SampleDb' 
        // connection string in the application configuration file.
        public SampleDbContext()
            : base("name=SampleDb")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
    }

    public class Item
    {
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

    public class ItemType
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "NameIsRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "NameIsTooLong")]
        [MinLength(2, ErrorMessageResourceName = "NameIsNotLongEnough", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Name { get; set; }
    }
}