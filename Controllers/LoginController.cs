using Auction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auction.Controllers
{
    public class LoginController : Controller
    {
        private readonly DBContext _context;

        public LoginController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Profile", "Profile");
            }

            ViewBag.Error = "Wrong login or password or user not exists";
            return View(model);
        }

    }

}
