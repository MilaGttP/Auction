using System.ComponentModel.DataAnnotations;

namespace Auction.Models
{
    public class Auction
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int StartPrice { get; set; }
        public int UserId { get; set; }

        public User CreationUser { get; set; }
    }
}