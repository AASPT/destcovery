namespace DestCovery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        [Key]
        public int Booking_Id { get; set; }

        public int Package_Id { get; set; }

        public int Tour_Id { get; set; }

        public int User_Id { get; set; }

        public int Persons_Enrolled { get; set; }

        public decimal Price_Per_Person { get; set; }

        public decimal Estimated_Price { get; set; }

        public DateTime Booking_Date { get; set; }

        public bool Booking_Status { get; set; }

        public virtual Package_Master Package_Master { get; set; }

        public virtual Package_Tour Package_Tour { get; set; }

        public virtual User_Info User_Info { get; set; }
    }
}
