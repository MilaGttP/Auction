namespace Auction.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public User CreationUser { get; set; }
    }
}
