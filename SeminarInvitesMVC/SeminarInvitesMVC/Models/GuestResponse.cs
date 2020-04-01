using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SeminarInvitesMVC
{
    public class GuestResponse
    {
        [Key]
        public int responseID { get; set; }
        [Required(ErrorMessage ="Please Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please enter your email address")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
        public string phone { get; set; }
        [Required(ErrorMessage ="please specify whether you'll attend")]
        public Nullable<bool> willAttend { get; set; }
        public string gender { get; set; }
    }
}