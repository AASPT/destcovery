using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DestCovery.Models
{
    public class Package_Tour
    {
        [Key]
        public int Tour_Id { get; set; }

        public int Package_Id { get; set; }

        public DateTime Tour_Start_Date { get; set; }

        public DateTime Tour_End_Date { get; set; }

        public Package_Master fk_for_Package_Id { get; set; }
            

    }
}