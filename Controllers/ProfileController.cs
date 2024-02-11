using Auction.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class ProfileController : Controller
    {
        private readonly DBContext _context;

        public ProfileController(DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var user = await _context.Users.FindAsync(userId.Value);
                if (user != null)
                {
                    return View(user);
                }
            }

            return RedirectToAction("Login", "Login");
        }
    }

}