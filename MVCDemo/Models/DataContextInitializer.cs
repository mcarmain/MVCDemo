using MVCDemo.WebApi.Models;
using System.Linq;
namespace MVCDemo
{
    public class DataContextInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        public override void InitializeDatabase(DataContext context)
        {
            if (context.Database.Exists())
            {
                if (!context.Database.CompatibleWithModel(true))
                {
                    context.Database.Delete();
                }
            }
            base.InitializeDatabase(context);
        }
        protected override void Seed(DataContext context)
        {

            if (context.Products.Count() == 0)
            {
                var item = new Product { ID = 1, Name = "One", Price = 1.23M, UnitsInStock = 123 };
                context.Products.Add(item);
                item = new Product { ID = 2, Name = "Two", Price = 2.34M, UnitsInStock = 234 };
                context.Products.Add(item);
                item = new Product { ID = 3, Name = "Three", Price = 3.45M, UnitsInStock = 345 };
                context.Products.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }

    }
}

