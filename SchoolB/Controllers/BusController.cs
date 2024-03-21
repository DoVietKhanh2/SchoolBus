using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PagedList;
using SchoolB.Models;
using System.Collections;

namespace SchoolB.Controllers
{
    public class BusController : Controller
    {
        SchoolBusContext context=new SchoolBusContext();
        public IActionResult Index()
        {
            return View();
            
        }
        public IActionResult BusList()
        {
            var data = context.Buses.Include(x=>x.Route).Include(y=>y.Driver).ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult BusList(int id)
        {
            var data = context.Buses.FirstOrDefault(b => b.BusId == id);
            return View(data);
        }
        public IActionResult BusDetail(int id)
        {
            var bus = context.Buses.Include(x=>x.Route).Include(y=>y.Driver).FirstOrDefault(b=>b.BusId == id);
            string driverName = bus.Driver.FullName;
            string driverPhone = bus.Driver.Phone;
            string routeName = bus.Route.RouteName;
            ViewBag.DriverName = driverName;
            ViewBag.DriverPhone = driverPhone;
            ViewBag.RouteName = routeName;
            return View(bus);
        }
        [HttpPost]
        public IActionResult BusDetail(bus bus, int routeid, int driverid)
        {
            var b = context.Buses.FirstOrDefault(x => x.BusId == bus.BusId);
            var existRouteId = context.Routes.FirstOrDefault(y => y.RouteId == routeid);
            var existDriverId = context.Drivers.FirstOrDefault(y => y.DriverId == driverid);
            if(existRouteId !=null && existDriverId != null)
            {
                b.DriverId = bus.DriverId;
                b.RouteId = bus.RouteId;
                context.SaveChanges();
                return RedirectToAction("BusList");
            }
            else
            {
                ViewBag.erorr = "driver va route khong ton tai";
                return View(bus);
            }
        }
        public IActionResult Delete(int id)
        {
            var b = context.Buses.FirstOrDefault(a => a.BusId == id);
            context.Buses.Remove(b);
            context.SaveChanges();
            return RedirectToAction("ListUsers");
        }
        
    }
}
