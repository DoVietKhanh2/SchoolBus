using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolB.Models;

namespace SchoolB.Controllers
{
    public class SignupController : Controller
    {
        SchoolBusContext context = new SchoolBusContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(User user, string repass)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện kiểm tra và xử lý thông tin đăng ký ở đây
                var existingUser = context.Users.FirstOrDefault(u => u.Username == user.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Username already exists.");
                    return View("Index", user);
                }
                if (user.Password != repass)
                {
                    ModelState.AddModelError("", "Password and Repassword do not match.");
                    return View("Index", user);
                }
                // Ví dụ: lưu thông tin người dùng vào cơ sở dữ liệu
                context.Users.Add(user);
                context.SaveChanges();

                
                return RedirectToAction("Index","Login");
            }
            else
            {
                // Nếu có lỗi, hiển thị lại trang đăng ký với thông báo lỗi
                
                return RedirectToAction("Index");
            }

        }
    }
}
