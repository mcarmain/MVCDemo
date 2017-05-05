using System.Data.Entity;

namespace MVCDemo.WebApi.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}