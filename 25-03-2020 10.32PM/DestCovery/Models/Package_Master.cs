using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DestCovery.Models
{
    public class Package_Master
    {
        [Key]
        public int Package_Id { get; set; }

        [Required]
        public string Package_Name { get; set; }

        public string Package_Tagline { get; set; }

        public string Package_Description { get; set; }

        public Double Package_Price { get; set; }

        public int Package_Total_Travellers{ get; set; }

        public bool Package_Status { get; set; }

        public string Package_Header_Image { get; set; }
    }
}