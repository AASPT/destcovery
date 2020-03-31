using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DestCovery.Models;

namespace DestCovery.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            using (DestCoveryContext dcc = new DestCoveryContext())
            {
                List<User_Info> users = dcc.Users.ToList();
                List<Package_Master> package_Masters = dcc.Package_mst.ToList();
                List<Bookings> booking = dcc.Booking_pckg.ToList();

                var record = from b in booking
                             join u in users on b.User_Id equals u.User_Id into table1
                             from u in table1.ToList()
                             join p in package_Masters on b.Package_Id equals p.Package_Id into table2
                             from p in table2.ToList()

                             select new ViewModel
                             {
                                 booking = b,
                                 user = u,
                                 package_mster = p

                             };
                return View(record);
            }
        }

        public ActionResult TotalPackage()
        {

            DestCoveryContext dcc = new DestCoveryContext();

            var data = dcc.Users;
            return View(data.ToList());
        }
    }
}