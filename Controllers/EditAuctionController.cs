using Auction.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class EditAuctionController : Controller
    {
        private readonly DBContext _context;

        public EditAuctionController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/EditAuction/EditAuction/{id:int}")]
        public IActionResult EditAuction(int id, string Name, string Description, int StartPrice)
        {
            var auction = _context.Auctions.FirstOrDefault(a => a.Id == id);

            if (auction != null)
            {
                auction.Name = Name;
                auction.Description = Description;
                auction.StartPrice = StartPrice;

                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error");
            }
        }

    }
}
