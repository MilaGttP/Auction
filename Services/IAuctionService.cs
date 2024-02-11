using Auction.Models;

namespace Auction.Services
{
    public interface IAuctionService
    {
        IEnumerable<Models.Auction> GetAllAuctions();
        IEnumerable<Models.Auction> GetAllAuctionsByOneUser();
        Models.Auction GetAuctionById(int id);
        User GetUserById(int id);
        public Bet GetLatestBet(int auctionId);
    }

    public class AuctionService : IAuctionService
    {
        private readonly DBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IEnumerable<Models.Auction> GetAllAuctions()
        {
            return _context.Auctions.ToList();
        }

        public AuctionService(DBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Models.Auction> GetAllAuctionsByOneUser()
        {
            var userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
            return _context.Auctions.Where(a => a.UserId == userId).ToList();
        }

        public Models.Auction GetAuctionById(int id)
        {
            return _context.Auctions.FirstOrDefault(a => a.Id == id);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public Bet GetLatestBet(int auctionId)
        {
            return _context.Bets
                           .Where(b => b.AuctionId == auctionId)
                           .OrderByDescending(b => b.Amount)
                           .FirstOrDefault();
        }
    }
}
