using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DestCovery.Models
{
    public class ContactUs
    {
        [Key]
        public int cid { get; set; }

        public string person_name { get; set; }

        public string person_email { get; set; }

        public string person_mobile { get; set; }

        public string person_msg { get; set; }
    }
}