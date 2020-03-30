using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DestCovery.Models
{
    public class ViewModel
    {
        public User_Info user { get; set; }
        public Package_Master package_mster { get; set; }
        public Bookings booking{ get; set; }
    }
}