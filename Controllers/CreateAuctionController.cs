using Auction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Auction.Controllers
{
    public class CreateAuctionController : Controller
    {
        private readonly DBContext _context;

        public CreateAuctionController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuction(Models.Auction model)
        {
            model.UserId = (int)HttpContext.Session.GetInt32("UserId");

            Models.Auction auction = new Models.Auction
            {
                Name = model.Name,
                Description = model.Description,
                StartPrice = model.StartPrice,
                UserId = model.UserId
            };

            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
