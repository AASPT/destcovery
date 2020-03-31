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
            if (Session["AdminID"] == null)
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

                return RedirectToAction("PackageDetails", "Admin", new { @packagename = pm.Package_Name });
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

        public ActionResult AddPackageSpot(int packageid, string packagename)
        {
            ViewBag.PACKAGEID = packageid;
            ViewBag.PACKAGENAME = packagename;

            TempData["PACKAGENAME"] = packagename;

            return View();
        }

        [HttpPost]
        public ActionResult AddPackageSpot(Package_Spots ps)
        {
            var name = ViewBag.PACKAGENAME;

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


        public ActionResult sample()
        {
            return View();
        }

        public ActionResult UpdateAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin_Info objadmin)
        {
            DestCoveryContext dcc = new DestCoveryContext();
            dcc.Admin.Add(objadmin);
            dcc.SaveChanges();
            return View();

        }

        public ActionResult AdminDetails()
        {
            DestCoveryContext dcc = new DestCoveryContext();

            return View(dcc.Admin.ToList());
        }

        public ActionResult Details(string id)
        {
            DestCoveryContext dcc = new DestCoveryContext();
            int adminId = Convert.ToInt32(id);
            var record = dcc.Admin.Find(adminId);
            return View(record);
        }

        public ActionResult Edit(string id)
        {
            DestCoveryContext dcc = new DestCoveryContext();
            int adminId = Convert.ToInt32(id);
            var record = dcc.Admin.Find(adminId);
            return View(record);
        }

        [HttpPost]
        public ActionResult Edit(Admin_Info objadmin)
        {
            DestCoveryContext dcc = new DestCoveryContext();
            var data = dcc.Admin.Find(objadmin.Admin_Id);
            if (data != null)
            {
                data.Admin_Name = objadmin.Admin_Name;
                data.Admin_Email = objadmin.Admin_Email;
                data.Admin_Password = objadmin.Admin_Password;
                data.Admin_Mobile = objadmin.Admin_Mobile;

            }

            dcc.SaveChanges();
            return View();
        }

        public ActionResult Delete(string id)
        {
            DestCoveryContext dcc = new DestCoveryContext();
            int adminId = Convert.ToInt32(id);
            var record = dcc.Admin.Find(adminId);
         //   dcc.Admin.Remove(record);
            //dcc.SaveChanges();
            return View(record);
        }
        [HttpPost]
        public ActionResult Delete(Admin_Info objadmin)
        {

            DestCoveryContext dcc = new DestCoveryContext();
            var data = dcc.Admin.Find(objadmin.Admin_Id);
            dcc.Admin.Remove(data);
            dcc.SaveChanges();
            return View("AdminDetails");
        }
    }
}








        

