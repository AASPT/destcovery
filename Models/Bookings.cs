using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DestCovery.Models
{
    public class Bookings
    {
        [Key]
        public int Booking_Id { get; set; }

        public int Package_Id { get; set; }

        public int Tour_Id { get; set; }

        public int User_Id { get; set; }

        public int Persons_Enrolled { get; set; }

        public Decimal Price_Per_Person { get; set; }

        public Decimal Estimated_Price { get; set; }

        public DateTime Booking_Date { get; set; }

        public bool Booking_Status { get; set; }

        public Package_Master fk_for_Package_Id { get; set; }

        public Package_Tour fk_for_Tour_Id { get; set; }

        public Package_Spots fk_for_Spot_Id { get; set; }

       
    }
}