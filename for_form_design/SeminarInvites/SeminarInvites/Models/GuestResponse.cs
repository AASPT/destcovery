using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SeminarInvites
{
    public class GuestResponse
    {
        [Key]
        [Required(ErrorMessage = "PLease Enter name ")]
        public string Name { get; set; }


        //[Required(ErrorMessage = "PLease Enter email ")]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PLease Enter Phone ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "PLease Enter Response")]
        public bool? WillAttend { get; set; }
    }
}