using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Models;
namespace MVCDemo
{
    public class SampleDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<SampleDb>
    {
        public override void InitializeDatabase(SampleDb context)
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
        protected override void Seed(SampleDb context)
        {

            var type1 = context.ItemTypes.Add(new ItemType { Id = 1, Name = "Type I" });
            var type2 = context.ItemTypes.Add(new ItemType { Id = 2, Name = "Type II" });
            context.Items.Add(new Item { Name = "Item One", Description = "The first by that name.", ItemType = type1 });
            context.Items.Add(new Item { Name = "Item Two", Description = "The second by that name.", ItemType = type2 });
            base.Seed(context);
        }

    }
}

