using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DestCovery.Models
{
    public class Admin_Info
    {
        [Key]
        public int Admin_Id { get; set; }

        [Required]
        public string Admin_Name { get; set; }

        [Required]
        public string Admin_Email { get; set; }

        [Required]
        public string Admin_Password { get; set; }

        [Required]
        public string Admin_Mobile { get; set; }

        public bool Admin_Status { get; set; }
    }
}