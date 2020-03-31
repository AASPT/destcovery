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

        public ActionResult PackageDetails(string packageid, string packagename)
        {
            ViewBag.PACKAGEID = packageid;
            ViewBag.PACKAGENAME = packagename;

            return View();
        }

        public ActionResult AddPackageSpot(int packageid,string packagename)
        {
            ViewBag.PACKAGEID = packageid;
            ViewBag.PACKAGENAME = packagename;

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
                }

                return RedirectToAction("AddPackageSpot", "Admin", new { @packagename = ViewBag.PACKAGENAME, @packageid = ViewBag.PACKAGEID });
            }
            else
            {
                return View();
            }
        }




    }
}