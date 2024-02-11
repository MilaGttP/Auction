using Auction.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
