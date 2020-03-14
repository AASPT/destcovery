using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeminarInvites.Models;

namespace SeminarInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.showtime = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }


        public ActionResult Register()
        {

            return View("Register");
        }

        public ActionResult About()
        {

            return View("about");
        }

        [HttpPost]
        public ViewResult Register(GuestResponse gr)
        {
            if (ModelState.IsValid)
            {
                using (var context = new UserContext())
                {
                    context.Guest.Add(gr);
                    context.SaveChanges();
                }
                    return View("Thanks", gr);
            }
            else
            {
                return View();
            }
        }

        public ActionResult ContactUS()
        {

            return View("ContactUS");
        }







        //public string add()
        //{
        //    return "Add Method called";
        //}
    }
}