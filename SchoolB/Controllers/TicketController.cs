using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolB.Models;
using System;

namespace SchoolB.Controllers
{
    public class TicketController : Controller
    {
        SchoolBusContext context = new SchoolBusContext();
        public IActionResult Index()
        {
            var userid = HttpContext.Session.GetInt32("UserId");
            if (userid == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {           
                var user = context.Users.FirstOrDefault(u=>u.UserId == userid);
                ViewBag.Phone = user.Phone;
                ViewBag.FullName = user.FullName;
                ViewBag.UserId = userid;
                ViewBag.Address = user.Address;                
                return View();
            }

        }
        [HttpPost]
        public IActionResult Index(Ticket ticket, int busid)
        {
            var bus = context.Buses.Include(y=>y.Route).FirstOrDefault(x=>x.BusId == busid);
            ViewBag.Routeid = bus.RouteId;
            ViewBag.RouteName = bus.Route.RouteName;
            return View(ticket);
        }
        [HttpPost]
        public IActionResult Bookticket(Ticket ticket, int check, string month)
        {
            var userid = HttpContext.Session.GetInt32("UserId");
            if (userid == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == userid);
                ViewBag.Phone = user.Phone;
                ViewBag.FullName = user.FullName;
                ViewBag.UserId = userid;
                ViewBag.Address = user.Address;
                
            }
            if(month == null)
            {
                ViewBag.erorr = "month not empty";
                return RedirectToAction("Index");
            }
            int checkede = 1;
            if (check != 0)
            {
                bus busa = context.Buses.Include(x => x.Route).FirstOrDefault(x => x.BusId == ticket.BusId);
                if (busa == null)
                {
                    ViewBag.Routename = "Bus khong ton tai";
                    return RedirectToAction("Index");
                }
                else
                {
                    int routeid = (int)busa.RouteId;
                    ticket.RouteId = routeid;
                    context.Tickets.Add(ticket);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");

                }

            }
            else
            {
                bus busa = context.Buses.Include(x => x.Route).FirstOrDefault(x => x.BusId == ticket.BusId);
                if(busa == null)
                {
                    ViewBag.Routename = "Bus khong ton tai";
                    return RedirectToAction("Index");
                }
                else
                {
                    int routeid = (int)busa.RouteId;
                    ticket.RouteId = routeid;
                    var route = context.Routes.SingleOrDefault(c => c.RouteId == routeid);
                    string routename = route.RouteName;
                    ViewBag.Routename = routename;
                    ViewBag.Checked = checkede;

                    return View("Index", ticket);
                }

            }
            
        }

    }
}
