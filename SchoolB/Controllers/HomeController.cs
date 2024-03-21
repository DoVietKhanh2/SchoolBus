using Microsoft.AspNetCore.Mvc;
using PagedList;
namespace SchoolB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult Tranghome()
        {
           return View();
        }

    }
}
