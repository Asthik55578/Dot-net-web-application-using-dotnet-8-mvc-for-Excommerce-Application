using Microsoft.AspNetCore.Mvc;
using MVCCourse2.Models;

namespace MVCCourse2.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                var validUser = UserRepository.ValidateUser(user.Username, user.Password);
                if (validUser != null)
                {
                    // Successful login logic (e.g., set session or redirect)
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid username or password.";
                }
            }
            return View(user);
        }
    }
}
