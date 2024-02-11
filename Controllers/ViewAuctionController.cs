using Auction.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class ViewAuctionController : Controller
    {
        public IActionResult ViewAuction()
        {
            return View();
        }
    }
}
