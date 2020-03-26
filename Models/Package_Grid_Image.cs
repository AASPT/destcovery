using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DestCovery.Models
{
    public class Package_Grid_Image
    {
        [Key]
        public int Package_GridImg_Id { get; set; }

        public int Package_Id { get; set; }

        public string Package_GridImg { get; set; }

        public Package_Master fk_for_Package_Id { get; set; }

    }
}