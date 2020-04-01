using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DestCovery.Models
{
    public class ViewModel
    {
        public List<Package_Master> package_master_vm { get; set; }

        public List<Package_Spots> package_spots_vm { get; set; }

        public List<Package_Tour> package_tour_vm { get; set; }

        public List<Package_Grid_Image> package_grid_vm { get; set; }

        public List<Package_Review> package_review_vm { get; set; }

        public Admin_Info admin_info_vm { get; set; }

        public List<User_Info> user_info_vm { get; set; }

        public List<Bookings> booking_vm { get; set; }
    }
}