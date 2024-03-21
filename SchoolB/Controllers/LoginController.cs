using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolB.Models;

namespace SchoolB.Controllers
{
    public class LoginController : Controller
    {
        SchoolBusContext context = new SchoolBusContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var authenticatedUser = context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (authenticatedUser != null)
            {
                // Successful login
                // You can set up authentication here, such as setting a cookie or session
                // For example, you can use HttpContext.Session.SetString("UserId", authenticatedUser.UserId.ToString());
                HttpContext.Session.SetInt32("UserId", authenticatedUser.UserId);
                
                // Then, redirect to a dashboard or authenticated page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Invalid credentials
                // You might want to display an error message or redirect back to the login page
                ViewBag.ErrorMessage = "Wrong username or password";
                return View("Index");
            }
        }
    }
}
