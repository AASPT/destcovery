using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DestCovery.Models
{
    public class Package_Review
    {
        [Key]
        public int Package_Review_Id { get; set; }

        public int Package_Id { get; set; }

        public int User_Id { get; set; }

        public string Package_Comment{ get; set; }

        public int Package_Rating { get; set; }

        public Package_Master fk_for_Package_Id { get; set; }

        public User_Info fk_for_User_Id { get; set; }


    }
}