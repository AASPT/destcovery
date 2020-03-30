using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DestCovery.Models
{
    public class User_Info
    {
        [Key]
        public int User_Id{ get; set; }

        public string User_Image { get; set; }

        [Required]
        public string User_Name { get; set; }

        [Required]
        public string User_Email { get; set; }

        [Required]
        public string User_Password { get; set; }

        public string User_Address { get; set; }

        public DateTime User_Dob { get; set; }

        [Required]
        public string User_Aadhar { get; set; }

        [Required]
        public string User_Mobile { get; set; }

        public bool User_Status { get; set; }
    }
}