
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
        public virtual DbSet<Book> Books { get; set; }
        //public virtual DbSet<Item> Albums { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
    }
}