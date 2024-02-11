using Auction.Models;
using Microsoft.AspNetCore.Mvc;

public class RegistrationController : Controller
{
    private readonly DBContext _context;

    public RegistrationController(DBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Register(User model)
    {
        if (ModelState.IsValid)
        {
            User user = new User
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Password = model.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Profile", "Profile");
        }

        return View("Error");
    }
}
