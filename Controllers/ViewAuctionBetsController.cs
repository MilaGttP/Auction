using Auction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auction.Controllers
{
    public class ViewAuctionBetsController : Controller
    {
        private readonly DBContext _context;

        public ViewAuctionBetsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/ViewAuctionBets/ViewAuctionBets/{id:int}")]
        public IActionResult ViewAuctionBets(int id)
        {
            var bets = _context.Bets
                               .Where(b => b.AuctionId == id)
                               .Include(b => b.CreationUser)
                               .ToList();

            return View(bets);
        }
    }
}
