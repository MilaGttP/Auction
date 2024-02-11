using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.Models
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }
        public int AuctionId { get; set; }

        [ForeignKey("UserId")]
        public User CreationUser { get; set; }
        public Auction Auction { get; set; }
    }
}
