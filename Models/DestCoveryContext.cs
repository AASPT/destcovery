using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DestCovery.Models
{
    public class DestCoveryContext :DbContext
    {
        public DestCoveryContext() : base("DestCoveryContext")
        {

        }
        public DbSet<User_Info> Users { get; set; }
        public DbSet<Admin_Info> Admin { get; set; }
        public DbSet<Package_Master> Package_mst { get; set; }
        public DbSet<Package_Spots> Package_spt { get; set; }
        public DbSet<Package_Review> Package_revws { get; set; }
        public DbSet<Package_Tour> Package_tor { get; set; }
        public DbSet<Package_Grid_Image> Package_gridimg { get; set; }
        public DbSet<Bookings> Booking_pckg { get; set; }

    }
}