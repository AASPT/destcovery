using DestCovery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DestCovery.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(Admin_Info admin)
        {
            if (!ModelState.IsValid)
            {
                using (DestCoveryContext dcc = new DestCoveryContext())
                {
                    var obj = dcc.Admin.Where(u => u.Admin_Email.Equals(admin.Admin_Email) && u.Admin_Password.Equals(admin.Admin_Password)).FirstOrDefault();

                    //var obj = dcc.user.Where((a => a.User_Name.Equals(user.User_Name)) && (a => a.User_Password.Equals(user.User_Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["AdminID"] = obj.Admin_Id.ToString();
                        Session["AdminName"] = obj.Admin_Name.ToString();

                        return RedirectToAction("TotalPackage", "Admin");
                    }
                }
            }
            ViewBag.LOGINMSG = "UserName OR Password Wrong. Try Again";
            return View(admin);
        }

        public ActionResult logout()
        {
            Session.Remove("AdminID");
            Session.Remove("AdminName");
            Session.RemoveAll();
            Session.Clear();

            return RedirectToAction("login", "Admin");
        }

        public ActionResult AddPackage()
        {
            if ( Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddPackage(Package_Master pm, HttpPostedFileBase postedFile)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    string fileName = System.IO.Path.GetFileName(postedFile.FileName);

                    //Set the Image File Path.
                    string filePath = "~/Uploads/package_img/" + fileName;

                    //Save the Image File in Folder.
                    postedFile.SaveAs(Server.MapPath(filePath));

                    using (var context = new DestCoveryContext())
                    {
                        context.Package_mst.Add(pm);

                        context.SaveChanges();
                    }

                    return RedirectToAction("PackageDetails", "Admin", new { @packagename = pm.Package_Name, @packageid = pm.Package_Id });
                }
                else
                {
                    return View();
                }
            }
        }

        public ActionResult TotalPackage()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                using (DestCoveryContext dcc = new DestCoveryContext())
                {
                    var data = dcc.Package_mst;

                    return View(data.ToList());
                }
            }
        }

        public ActionResult PackageDetails(int packageid, string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;

                var db = new DB_MODEL();

                //package master = using package id
                var package__master = (from a in db.Package_Master where a.Package_Id == packageid select a).ToList();

                //package spot = using pacage id
                var package__spot = (from a in db.Package_Spots where a.Package_Id == packageid select a).ToList();

                //package tour 
                var package__tour = (from a in db.Package_Tour where a.Package_Id == packageid select a).ToList();

                //package grid
                var package__gird = (from a in db.Package_Grid_Image where a.Package_Id == packageid select a).ToList();

                //package review
                var package__review = (from a in db.Package_Review where a.Package_Id == packageid select a).ToList();

                var model = new ViewModel { package_master_vm = package__master, package_spots_vm = package__spot, package_tour_vm = package__tour, package_grid_vm = package__gird, package_review_vm = package__review };

                return View(model);
            }
        }

        public ActionResult AddPackageSpot(int packageid,string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;

                TempData["PACKAGENAME"] = packagename;

                return View();
            }
        }

        [HttpPost]
        public ActionResult AddPackageSpot(Package_Spots ps)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    using (var context = new DestCoveryContext())
                    {
                        context.Package_spt.Add(ps);

                        context.SaveChanges();

                        return RedirectToAction("PackageDetails", "Admin", new { @packageid = ps.Package_Id, @packagename = TempData["PACKAGENAME"] });
                    }
                }
                else
                {
                    return View();
                }
            }
        }

        public ActionResult AddPackageImages(int packageid, string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;

                TempData["PACKAGENAME"] = packagename;

                return View();
            }
        }

        [HttpPost]
        public ActionResult AddPackageImages(Package_Grid_Image pi, HttpPostedFileBase postedFile)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    string fileName = System.IO.Path.GetFileName(postedFile.FileName);

                    //Set the Image File Path.
                    string filePath = "~/Uploads/package_img/" + fileName;

                    //Save the Image File in Folder.
                    postedFile.SaveAs(Server.MapPath(filePath));

                    using (var context = new DestCoveryContext())
                    {
                        context.Package_gridimg.Add(pi);

                        context.SaveChanges();
                    }

                    return RedirectToAction("PackageDetails", "Admin", new { @packageid = pi.Package_Id, @packagename = TempData["PACKAGENAME"] });
                }
                else
                {
                    return View();
                }
            }
        }

        public ActionResult AddPackageTour(int packageid, string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;

                TempData["PACKAGENAME"] = packagename;

                return View();
            }
        }

        [HttpPost]
        public ActionResult AddPackageTour(Package_Tour pt)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    using (var context = new DestCoveryContext())
                    {
                        context.Package_tor.Add(pt);

                        context.SaveChanges();

                        return RedirectToAction("PackageDetails", "Admin", new { @packageid = pt.Package_Id, @packagename = TempData["PACKAGENAME"] });
                    }
                }
                else
                {
                    return View();
                }
            }
        }


        public ActionResult bookingpending()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                var db = new DB_MODEL();       

                var bookings__ = (from a in db.Bookings where a.Booking_Status == "pending" select a).ToList();

                var package__master = (from a in db.Package_Master  select a).ToList();

                var package__tour = (from a in db.Package_Tour select a).ToList();

                var user__info = (from a in db.User_Info select a).ToList();

                var model = new ViewModel { package_master_vm = package__master, package_tour_vm = package__tour , booking_vm = bookings__ , user_info_vm = user__info };

                return View(model);
            }
        }

        public ActionResult bookingconfirm()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                var db = new DB_MODEL();

                var bookings__ = (from a in db.Bookings where a.Booking_Status == "Confirm" select a).ToList();

                var package__master = (from a in db.Package_Master select a).ToList();

                var package__tour = (from a in db.Package_Tour select a).ToList();

                var user__info = (from a in db.User_Info select a).ToList();

                var model = new ViewModel { package_master_vm = package__master, package_tour_vm = package__tour, booking_vm = bookings__, user_info_vm = user__info };

                return View(model);
            }
        }

        public ActionResult bookingcancel()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                var db = new DB_MODEL();

                var bookings__ = (from a in db.Bookings where a.Booking_Status == "Admin Cancel" || a.Booking_Status == "User Cancelled" select a).ToList();

                var package__master = (from a in db.Package_Master select a).ToList();

                var package__tour = (from a in db.Package_Tour select a).ToList();

                var user__info = (from a in db.User_Info select a).ToList();

                var model = new ViewModel { package_master_vm = package__master, package_tour_vm = package__tour, booking_vm = bookings__, user_info_vm = user__info };

                return View(model);
            }
        }

        public ActionResult ConfirmBooking(Bookings b,int bookingid,string user_no)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                DestCoveryContext dcc = new DestCoveryContext();
                var data = dcc.Booking_pckg.Where(x => x.Booking_Id == bookingid).FirstOrDefault();
                if (data != null)
                {
                    data.Booking_Status = "Confirm";
                }
                dcc.SaveChanges();

                MesageService ms = new MesageService();

                string msg = "Welcome Sir/Madam !! Thank you for choosing us. I hope we will give some amazing experience throuout this tour. Let us know how it goes. Best wishes for a safe, happy, and healthy journey!! I hope you continue to enjoy our services! DESTCOVERY :) ";
                ms.TextLocal(user_no, msg);

                return RedirectToAction("bookingpending", "Admin");
            }
        }

        public ActionResult CancelBooking(Bookings b, int bookingid,string user_no)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                DestCoveryContext dcc = new DestCoveryContext();
                var data = dcc.Booking_pckg.Where(x => x.Booking_Id == bookingid).FirstOrDefault();
                if (data != null)
                {
                    data.Booking_Status = "Admin Cancel";
                }
                dcc.SaveChanges();

                MesageService ms = new MesageService();

                string msg = "Thank you for choosing us but sorry to inform you unfortunately this Tour / Package is not availble for you. If there’s anything else we can help you with, please let us know. DESTCOVERY :) ";
                ms.TextLocal(user_no, msg);

                return RedirectToAction("bookingpending", "Admin");
            }
        }

        public ActionResult DeleteImage(int imageid,int packageid,string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;

                using (var dcc = new DestCoveryContext())
                {
                    var gridimage = dcc.Package_gridimg.Where(x => x.Package_GridImg_Id == imageid).FirstOrDefault();

                    dcc.Entry(gridimage).State = System.Data.Entity.EntityState.Deleted;
                    dcc.SaveChanges();
                }

                return RedirectToAction("PackageDetails", "Admin" , new { @packageid = packageid, @packagename = packagename });
            }
        }

        public ActionResult DeleteTour(int tourid, int packageid, string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;

                using (var dcc = new DestCoveryContext())
                {
                    var gridimage = dcc.Package_tor.Where(x => x.Tour_Id == tourid).FirstOrDefault();

                    dcc.Entry(gridimage).State = System.Data.Entity.EntityState.Deleted;
                    dcc.SaveChanges();
                }

                return RedirectToAction("PackageDetails", "Admin", new { @packageid = packageid, @packagename = packagename });
            }
        }

        public ActionResult DeleteSpot(int spotid, int packageid, string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;

                using (var dcc = new DestCoveryContext())
                {
                    var gridimage = dcc.Package_spt.Where(x => x.Spot_Id == spotid).FirstOrDefault();

                    dcc.Entry(gridimage).State = System.Data.Entity.EntityState.Deleted;
                    dcc.SaveChanges();
                }

                return RedirectToAction("PackageDetails", "Admin", new { @packageid = packageid, @packagename = packagename });
            }
        }

        public ActionResult UpdatePackageSpot(int spotid,int packageid, string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;
       
                DestCoveryContext dcc = new DestCoveryContext();
                int spot__id = Convert.ToInt32(spotid);
                var record = dcc.Package_spt.Find(spot__id);
                return View(record);          
            }
        }

        [HttpPost]
        public ActionResult UpdatePackageSpot(Package_Spots ps, int packageid, string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;

                DestCoveryContext dcc = new DestCoveryContext();
                var data = dcc.Package_spt.Find(ps.Spot_Id);
                if (data != null)
                {
                    data.Spot_Name = ps.Spot_Name;
                    data.Spot_Description = ps.Spot_Description;
                }

                dcc.SaveChanges();
                return RedirectToAction("PackageDetails", "Admin", new { @packageid = packageid, @packagename = packagename });
            }
        }

        public ActionResult UpdatePackage(int packageid, string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;

                DestCoveryContext dcc = new DestCoveryContext();
                int package__id = Convert.ToInt32(packageid);
                var record = dcc.Package_mst.Find(package__id);
                return View(record);
            }
        }

        [HttpPost]
        public ActionResult UpdatePackage(Package_Master pm, int packageid, string packagename)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                ViewBag.PACKAGEID = packageid;
                ViewBag.PACKAGENAME = packagename;

                DestCoveryContext dcc = new DestCoveryContext();
                var data = dcc.Package_mst.Find(pm.Package_Id);
                if (data != null)
                {
                    data.Package_Tagline = pm.Package_Tagline;
                    data.Package_Description = pm.Package_Description;
                    data.Package_Price = pm.Package_Price;
                }

                dcc.SaveChanges();
                return RedirectToAction("PackageDetails", "Admin", new { @packageid = packageid, @packagename = packagename });
            }
        }

        public ActionResult enquire()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                using (DestCoveryContext dcc = new DestCoveryContext())
                {
                    var data = dcc.Contact_Us;
                    return View(data.ToList());
                }
            }
        }

    }
}