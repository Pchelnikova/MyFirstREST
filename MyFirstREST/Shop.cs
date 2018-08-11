namespace MyFirstREST
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.Serialization;

    public class Shop : DbContext
    {
        // Your context has been configured to use a 'Shop' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MyFirstREST.Shop' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Shop' 
        // connection string in the application configuration file.
        public Shop()

            : base("name=Shop")
        {
            Database.SetInitializer<Shop>(new MyInit<Shop>());
        }

         public virtual DbSet<User> Users { get; set; }
         public virtual DbSet<Item> Items { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    [DataContract]
    public class UserWeb
    {
        // [JsonProperty]
        [DataMember]
        public int Id { get; set; }
        // [JsonProperty]
        [DataMember]
        public string Login { get; set; }
        //  [JsonProperty]
        [DataMember]
        public string Password { get; set; }
    }
}