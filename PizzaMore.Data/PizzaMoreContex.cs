using PizzaMore.Models;

namespace PizzaMore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaMoreContex : DbContext
    {
        // Your context has been configured to use a 'PizzaMoreContex' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PizzaMore.Data.PizzaMoreContex' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PizzaMoreContex' 
        // connection string in the application configuration file.
        public PizzaMoreContex()
            : base("name=PizzaMoreContex")
        {
        }
        
        public virtual DbSet<Pizza> PizzaSugestions { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}