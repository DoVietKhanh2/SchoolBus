using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolB.Models;

namespace SchoolB.Controllers
{
    public class UserController : Controller
    {
        SchoolBusContext context = new SchoolBusContext();
        public IActionResult Index()
        {
            return View();
        }
         
        public IActionResult Profile()
        {           
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;           
            if (userId == 0)
            {             
                return RedirectToAction("Index", "Login");
            }           
            User user = context.Users.FirstOrDefault(u => u.UserId == userId);          
            if (user == null)
            {              
                return NotFound(); 
            }            
            return View("Index", user);
        }
        [HttpPost]
        public IActionResult ChangePass(string currentPass, string newPass, string reNewpass)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if(userId == 0)
            {
                return RedirectToAction("Index", "Login");

            }
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound();
            }
            if(currentPass != user.Password)
            {
                ModelState.AddModelError("Password", "Incorrect current password");
                return View("Index",user);
            }
            if (newPass.Equals(user.Password))
            {
                ModelState.AddModelError("Password", "The new password cannot be the same as the old password");
                return View("Index", user);
            }
            if(reNewpass != newPass)
            {
                ModelState.AddModelError("Password", "The re-new password must be the same as the new password");
                return View("Index", user);
            }
            user.Password = newPass;
            context.Users.Update(user);
            context.SaveChanges();
            ViewBag.Notification = "changed password successfully";
            return View("Index", user);
        }
        public IActionResult Edit(int id)
        {
            var data = context.Users.FirstOrDefault(u => u.UserId == id);

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            var u = context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            u.FullName = user.FullName;
            u.Address = user.Address;
            u.Password = user.Password;
            u.Phone = user.Phone;
            u.Username = user.Username;
            context.SaveChanges();
            
            return RedirectToAction("ListUsers");
        }
        public IActionResult ListUsers()
        {           
            var data = context.Users.Where(u => u.UserId != 1).ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult ListUsers(int userid)
        {          
            var data = context.Users.Where(u => u.UserId == userid).ToList();
            return View("ProfileUser",data);
        }
        public IActionResult Delete(int idd)
        {
            var u = context.Users.FirstOrDefault(u => u.UserId == idd);            
            context.Users.Remove(u);
            context.SaveChanges();
            return RedirectToAction("ListUsers");
        }

    }
}
