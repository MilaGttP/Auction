using Auction.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class BetController : Controller
    {
        private readonly DBContext _context;

        public BetController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/Bet/MakeBet/{id:int}")]
        public IActionResult MakeBet(int id)
        {
            ViewBag.AuctionId = id;
            return View();
        }

        [HttpPost]
        [Route("/Bet/MakeBet/{id:int}")]
        public IActionResult MakeBet(int id, int Amount)
        {
            var auction = _context.Auctions.FirstOrDefault(a => a.Id == id);

            if (auction != null)
            {
                var highestBet = _context.Bets.Where(b => b.AuctionId == id).OrderByDescending(b => b.Amount).FirstOrDefault();
                if (Amount <= auction.StartPrice || (highestBet != null && Amount <= highestBet.Amount))
                {
                    TempData["Error"] = "The bet must be higher compare to previous";
                    return RedirectToAction("Index", "Home");
                }

                if (HttpContext.Session.GetInt32("UserId") == null)
                {
                    TempData["Error"] = "You must login or register";
                }

                else
                {
                    var newBet = new Bet { Amount = Amount, UserId = (int)HttpContext.Session.GetInt32("UserId"), AuctionId = id };
                    _context.Bets.Add(newBet);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error");
            }
        }

    }
}
