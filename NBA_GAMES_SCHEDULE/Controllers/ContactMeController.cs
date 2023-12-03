using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBA_GAMES_SCHEDULE.Models;
using static NBA_GAMES_SCHEDULE.Models.UserMessage;

namespace NBA_GAMES_SCHEDULE.Controllers
{
    public class ContactMeController : Controller
    {
        private readonly MVCDBcontext _context;

        public ContactMeController(MVCDBcontext context)
        {
            _context = context;
        }

        public IActionResult ContactMe()
        {
            return View();
        }

        public IActionResult MessageSent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactMe(Models.UserMessage userMessage)
        {
            if (ModelState.IsValid)
            {
                
                _context.UserMessages.Add(userMessage);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Twoja wiadomość została wysłana!";
                return RedirectToAction("MessageSent");
            }
            return View(userMessage);
        }

    }
}
