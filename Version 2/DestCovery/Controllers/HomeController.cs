using DestCovery.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
using System.Collections;
using System;
using DestCovery.Models;
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
            return View();
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
        //xxxxxxxxxxxxxxxxxxxxxxxModule :User Registration Form Ended Abovexxxxxxxxxxxxxxxxxxxxxxxxxxxxx-----

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(User_Info user)
        {
           if(!ModelState.IsValid)
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
            ViewBag.LOGINMSG = "UserName OR Password Wrong. Try Again";
            return View(user);
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
//}