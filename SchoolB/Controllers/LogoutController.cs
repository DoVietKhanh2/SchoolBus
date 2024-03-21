using Microsoft.AspNetCore.Mvc;

namespace SchoolB.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            // Xóa thông tin đăng nhập từ Session khi người dùng đăng xuất
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.SetInt32("UserId", 0);

            return RedirectToAction("Index", "Login");
        }
    }
}
