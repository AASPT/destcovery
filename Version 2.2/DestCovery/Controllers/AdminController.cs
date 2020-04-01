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

                        return RedirectToAction("admin_dashboard", "Admin");
                    }
                }
            }
            ViewBag.LOGINMSG = "UserName OR Password Wrong. Try Again";
            return View(admin);
        }

        public ActionResult admin_dashboard()
        {
            if(Session["AdminID"] == null)
            {
                return RedirectToAction("login", "Admin");
            }
            else
            {
                return View();
            }     
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
            if (Session["AdminID"] == null)
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

                return RedirectToAction("PackageDetails", "Admin", new { @packagename = pm.Package_Name , @packageid = pm.Package_Id });
            }
            else
            {
                return View();
            }
        }

        public ActionResult TotalPackage()
        {
            using (DestCoveryContext dcc = new DestCoveryContext())
            {            
                var data = dcc.Package_mst;
     
                return View(data.ToList());
            }  
        }

        public ActionResult PackageDetails(int packageid, string packagename)
        {
            ViewBag.PACKAGEID = packageid;
            ViewBag.PACKAGENAME = packagename;

            var db = new DB_MODEL();

            int status_data = 0;

            //package master = using package id
            var package__master = (from a in db.Package_Master where a.Package_Id == packageid where a.Package_Status == false select a).ToList();

            //package spot = using pacage id
            var package__spot = (from a in db.Package_Spots where a.Package_Id == packageid select a).ToList();

            //package tour 
            var package__tour = (from a in db.Package_Tour where a.Package_Id == packageid select a).ToList();

            //package grid
            var package__gird = (from a in db.Package_Grid_Image where a.Package_Id == packageid  select a).ToList();

            //package review
            var package__review = (from a in db.Package_Review where a.Package_Id == packageid select a).ToList();

            var model = new ViewModel{ package_master_vm = package__master, package_spots_vm = package__spot , package_tour_vm = package__tour , package_grid_vm = package__gird, package_review_vm = package__review };

            return View(model);
        }

        public ActionResult AddPackageSpot(int packageid,string packagename)
        {
            ViewBag.PACKAGEID = packageid;
            ViewBag.PACKAGENAME = packagename;

            TempData["PACKAGENAME"] = packagename;

            return View();
        }

        [HttpPost]
        public ActionResult AddPackageSpot(Package_Spots ps)
        {     
            if (ModelState.IsValid)
            {
                using (var context = new DestCoveryContext())
                {
                    context.Package_spt.Add(ps);

                    context.SaveChanges();

                    return RedirectToAction("PackageDetails", "Admin", new { @packageid = ps.Package_Id,@packagename= TempData["PACKAGENAME"] });
                }      
            }
            else
            {
                return View();
            }
        }

        public ActionResult AddPackageImages(int packageid, string packagename)
        {
            ViewBag.PACKAGEID = packageid;
            ViewBag.PACKAGENAME = packagename;

            TempData["PACKAGENAME"] = packagename;

            return View();
        }

        [HttpPost]
        public ActionResult AddPackageImages(Package_Grid_Image pi, HttpPostedFileBase postedFile)
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

        public ActionResult AddPackageTour(int packageid, string packagename)
        {
            ViewBag.PACKAGEID = packageid;
            ViewBag.PACKAGENAME = packagename;

            TempData["PACKAGENAME"] = packagename;

            return View();
        }

        [HttpPost]
        public ActionResult AddPackageTour(Package_Tour pt)
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
}