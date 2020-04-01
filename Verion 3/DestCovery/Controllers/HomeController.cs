using DestCovery.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
using System.Collections;
using System;

using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace DestCovery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new DB_MODEL();
            var package__master = (from a in db.Package_Master select a).ToList();
            var model = new ViewModel { package_master_vm = package__master };

            return View(model);
        }

        // GET: Home
        public ActionResult User_Registraion_Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult User_Registraion_Form(User_Info dcc, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                string fileName = System.IO.Path.GetFileName(postedFile.FileName);

                //Set the Image File Path.
                string filePath = "~/Uploads/user_img/" + fileName;

                //Save the Image File in Folder.
                postedFile.SaveAs(Server.MapPath(filePath));

                using (var context = new DestCoveryContext())
                {
                    context.Users.Add(dcc);
                    context.SaveChanges();
                }

                ViewBag.LOGINMSG = "Registered Successfully. Please Login";

                return RedirectToAction("login", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(User_Info user)
        {
            if (ModelState.IsValid)
            {
                using (DestCoveryContext dcc = new DestCoveryContext())
                {
                    var obj = dcc.Users.Where(u => u.User_Email.Equals(user.User_Email) && u.User_Password.Equals(user.User_Password)).FirstOrDefault();

                    //var obj = dcc.user.Where((a => a.User_Name.Equals(user.User_Name)) && (a => a.User_Password.Equals(user.User_Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.User_Id.ToString();
                        Session["UserName"] = obj.User_Name.ToString();

                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();

        }

        public ActionResult check(int packageid, string packagename)
        {
            ViewBag.PACKAGEIDT = packageid;
            ViewBag.PACKAGENAMET = packagename;

            if (Session["UserID"] == null)
            {
                return RedirectToAction("logintobook", "Home", new { @packageid = packageid, @packagename = packagename });
            }
            else
            {
                return RedirectToAction("BookThisTour", "Home", new { @packageid = packageid, @packagename = packagename });
            }
        }


        public ActionResult logintobook(int packageid, string packagename)
        {
            ViewBag.PACKAGEIDT = packageid;
            ViewBag.PACKAGENAMET = packagename;

            TempData["PACKAGEIDT"] = packageid;
            TempData["PACKAGENAMET"] = packagename;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult logintobook(User_Info user)
        {
            if (ModelState.IsValid)
            {
                using (DestCoveryContext dcc = new DestCoveryContext())
                {
                    var obj = dcc.Users.Where(u => u.User_Email.Equals(user.User_Email) && u.User_Password.Equals(user.User_Password)).FirstOrDefault();

                    //var obj = dcc.user.Where((a => a.User_Name.Equals(user.User_Name)) && (a => a.User_Password.Equals(user.User_Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.User_Id.ToString();
                        Session["UserName"] = obj.User_Name.ToString();

                        return RedirectToAction("BookThisTour", "Home", new { @packageid = TempData["PACKAGEIDT"], @packagename = TempData["PACKAGENAMET"] });
                    }
                }
            }
            ViewBag.LOGINMSG = "UserName OR Password Wrong. Try Again";
            return View();
        }

        public ActionResult Tours()
        {
            var db = new DB_MODEL();
            var package__master = (from a in db.Package_Master select a).ToList();
            var model = new ViewModel { package_master_vm = package__master };

            return View(model);
        }

        public ActionResult TourDetails(int packageid, string packagename)
        {
            ViewBag.PACKAGEIDT = packageid;
            ViewBag.PACKAGENAMET = packagename;

            var db = new DB_MODEL();

            //package master = using package id
            var package__master = (from a in db.Package_Master where a.Package_Id == packageid select a).ToList();

            //package spot = using pacage id
            var package__spot = (from a in db.Package_Spots where a.Package_Id == packageid select a).ToList();

            //package tour 
            var package__tour = (from a in db.Package_Tour where a.Package_Id == packageid && a.Tour_Start_Date > DateTime.Now select a).ToList();

            //package grid
            var package__gird = (from a in db.Package_Grid_Image where a.Package_Id == packageid select a).ToList();

            //package review
            var package__review = (from a in db.Package_Review where a.Package_Id == packageid select a).ToList();

            var user__info = (from a in db.User_Info select a).ToList();

            var model = new ViewModel { package_master_vm = package__master, package_spots_vm = package__spot, package_tour_vm = package__tour, package_grid_vm = package__gird, package_review_vm = package__review, user_info_vm = user__info };

            return View(model);
        }


        public ActionResult BookThisTour(int packageid, string packagename)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                ViewBag.PACKAGEIDT = packageid;
                ViewBag.PACKAGENAMET = packagename;

                var db = new DB_MODEL();

                //package master = using package id
                var package__master = (from a in db.Package_Master where a.Package_Id == packageid select a).ToList();

                //package tour 
                var package__tour = (from a in db.Package_Tour where a.Package_Id == packageid && a.Tour_Start_Date > DateTime.Now select a).ToList();

                var model = new ViewModel { package_master_vm = package__master, package_tour_vm = package__tour };

                return View(model);
            }
        }

        public ActionResult BookNow(int packageid, string packagename, int tourid, int price)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                ViewBag.PACKAGEIDT = packageid;
                ViewBag.PACKAGENAMET = packagename;
                ViewBag.PACKAGETOURIDT = tourid;
                ViewBag.PACKAGEPRICET = price;

                return View();
            }
        }

        [HttpPost]
        public ActionResult BookNow(Bookings dcc)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    using (var context = new DestCoveryContext())
                    {
                        context.Booking_pckg.Add(dcc);

                        context.SaveChanges();
                    }
                    return RedirectToAction("Bookings", "Home");
                }
                else
                {
                    return View();
                }
            }

        }

        public ActionResult Bookings()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                int user__id = Convert.ToInt32(Session["UserID"]);

                var db = new DB_MODEL();

                var package__master = (from a in db.Package_Master select a).ToList();

                var booking = (from a in db.Bookings where a.User_Id == user__id select a).ToList();

                var tour__package = (from a in db.Package_Tour select a).ToList();

                var package_reviews = (from a in db.Package_Review where a.User_Id == user__id select a).ToList();

                var model = new ViewModel { booking_vm = booking, package_master_vm = package__master, package_tour_vm = tour__package };

                return View(model);
            }
        }


        public ActionResult BookingCancel(Bookings b, int bookingid)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                DestCoveryContext dcc = new DestCoveryContext();
                var data = dcc.Booking_pckg.Where(x => x.Booking_Id == bookingid).FirstOrDefault();
                if (data != null)
                {
                    data.Booking_Status = "User Cancelled";
                }
                dcc.SaveChanges();
                return RedirectToAction("Bookings", "Home");
            }
        }

        public ActionResult AddReview(int packageid, string packagename)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                ViewBag.PACKAGEIDT = packageid;
                ViewBag.PACKAGENAMET = packagename;

                return View();
            }
        }

        [HttpPost]
        public ActionResult AddReview(Package_Review pr)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    using (var context = new DestCoveryContext())
                    {
                        context.Package_revws.Add(pr);
                        context.SaveChanges();
                    }

                    return RedirectToAction("Bookings", "Home");
                }
                else
                {
                    return View();
                }
            }
        }

        public ActionResult user_reviews()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                int user__id = Convert.ToInt32(Session["UserID"]);

                var db = new DB_MODEL();

                var package__review = (from a in db.Package_Review where a.User_Id == user__id select a).ToList();

                var package__master = (from a in db.Package_Master select a).ToList();

                var model = new ViewModel { package_review_vm = package__review, package_master_vm = package__master };

                return View(model);
            }
        }

        public ActionResult user_info()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                int user__id = Convert.ToInt32(Session["UserID"]);

                var db = new DB_MODEL();

                var user__info = (from a in db.User_Info where a.User_Id == user__id select a).ToList();

                var model = new ViewModel { user_info_vm = user__info };

                return View(model);
            }
        }

        public ActionResult change_password()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                return View();        
            }
        }

        [HttpPost]
        public ActionResult change_password(User_Info ui)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                int user__id = Convert.ToInt32(Session["UserID"]);
                DestCoveryContext dcc = new DestCoveryContext();
                var data = dcc.Users.Where(x => x.User_Id == user__id).FirstOrDefault();
                if (data != null)
                {
                    data.User_Password = ui.User_Password;
                }
                dcc.SaveChanges();
                return RedirectToAction("user_info", "Home");
            }

        }

        public ActionResult logout()
        {
            Session.Remove("UserID");
            Session.Remove("UserName");
            Session.RemoveAll();
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult dashboard()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                return View();
            }
        }

    }
}
