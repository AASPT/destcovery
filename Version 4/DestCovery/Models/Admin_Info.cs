namespace DestCovery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin_Info
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

        public string Admin_Status { get; set; }
    }
}
