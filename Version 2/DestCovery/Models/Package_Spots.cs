using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DestCovery.Models
{
    public class Package_Spots
    {
        [Key]
        public int Spot_Id { get; set; }

        public int Package_Id { get; set; }

        public string Spot_Name { get; set; }

        public string Spot_Description { get; set; }

        public Package_Master fk_for_Package_Id { get; set; }



        
    }
}