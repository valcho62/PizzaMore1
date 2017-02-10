using System.ComponentModel.DataAnnotations;

namespace PizzaMore.Models
{
    public class Session
    {
        [Key]
        public string Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public override string ToString()
        {
            return $"{this.Id}\t{this.User.Id}";
        }
    }
}