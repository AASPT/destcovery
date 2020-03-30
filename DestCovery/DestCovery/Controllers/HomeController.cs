using DestCovery.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
using System.Collections;
using System;

namespace DestCovery.Controllers
{
    public class HomeController : Controller
    {
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
                string filePath = "~/Uploads/" + fileName;

                //Save the Image File in Folder.
                postedFile.SaveAs(Server.MapPath(filePath));

                

                using (var context = new DestCoveryContext())
                {
                    context.Users.Add(dcc);
                   
                    context.SaveChanges();
                }
                return View("Thanks", dcc);
            }
            else
            {
                return View();
            }
        }
        //xxxxxxxxxxxxxxxxxxxxxxxModule :User Registration Form Ended Abovexxxxxxxxxxxxxxxxxxxxxxxxxxxxx-----
        //[HttpGet]
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(User_Info user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (DestCoveryContext dcc = new DestCoveryContext())
        //        {
        //            var obj = dcc.User_Info.Where((a => a.User_Name.Equals(user.User_Name)) && (a => a.User_Password.Equals(user.User_Password)).FirstOrDefault();
        //            if (obj != null)
        //            {
        //                Session["UserID"] = obj.UserId.ToString();
        //                Session["UserName"] = obj.UserName.ToString();
        //                return RedirectToAction("UserDashBoard");
        //            }
        //        }
        //    }
        //    return View();
        //}

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("User_Login");
            }
        }
    }





}
}