using System;
using System.Collections.Generic;


namespace PizzaMore.Models
{
    public class User
    {
        public User()
        {
            this.Sugestions = new HashSet<Pizza>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Pizza> Sugestions { get; set; }
    }
}
