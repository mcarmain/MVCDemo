using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Models;
namespace MVCDemo
{
    //public class SampleDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SampleDbContext>
    public class SampleDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SampleDbContext>
    {
        public override void InitializeDatabase(SampleDbContext context)
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
        protected override void Seed(SampleDbContext context)
        {

            var type1 = context.ItemTypes.Add(new ItemType { Id = 1, Name = "Type I" });
            var type2 = context.ItemTypes.Add(new ItemType { Id = 2, Name = "Type II" });
            context.Items.Add(new Item { Name = "Item One", Description = "The first by that name.", ItemType = type1 });
            context.Items.Add(new Item { Name = "Item Two", Description = "The second by that name.", ItemType = type2 });


            var phones = new List<Phone>
            {
            new Phone{Model="IPhone 8 Plus 512GB", Company="Apple",Price= 999},
            new Phone{Model="IPhone 6 Plus 256GB", Company="Apple",Price= 899},
            new Phone{Model="IPhone 8 Plus 128GB", Company="Apple",Price= 799},
             new Phone{Model="IPhone 8 512GB", Company="Apple",Price= 799},
            new Phone{Model="IPhone 7 256GB", Company="Apple",Price= 699},
            new Phone{Model="IPhone 6 128GB", Company="Apple",Price= 599},
             new Phone{Model="Samsung Galaxy 0", Company="Samsung",Price= 9}
            };
            phones.ForEach(p => context.Phones.Add(p));

            var type3 = context.BookGenres.Add(new BookGenre { Id = 1, Name = "Mystery" });
            var type4 = context.BookGenres.Add(new BookGenre { Id = 2, Name = "Drama" });
            var type5 = context.BookGenres.Add(new BookGenre { Id = 2, Name = "Adventure" });
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book { Title ="Title1",Summary="Summary1",BookGenreId=1,Publisher="Publisher1",Author="Author1"},
                 new Book { Title ="Title2",Summary="Summary2",BookGenreId=2,Publisher="Publisher2",Author="Author2"},
                 new Book { Title ="Title3",Summary="Summary3",BookGenreId=3,Publisher="Publisher3",Author="Author3"}
            };
            books.ForEach(b => context.Books.Add(b));

            context.SaveChanges();
            base.Seed(context);
        }

    }
}

