using System.Data.Entity;

namespace MyFirstREST
{
    internal class MyInit<T> : DropCreateDatabaseAlways<Shop>
    {
        protected override void Seed(Shop context)
        {
            context.Users.Add(new User { Login = "1", Password = "1" });
            context.Items.Add(new Item {Name = "Dress", Price = 1500 });
            context.Items.Add(new Item { Name = "Dress", Price = 1800 });

            context.SaveChanges();
        }
    }
}