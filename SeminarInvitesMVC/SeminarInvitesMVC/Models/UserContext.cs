using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeminarInvitesMVC.Models
{
    public class UserContext:DbContext
    {
        public UserContext():base("UserContext")
        {

        }
        public DbSet<GuestResponse> guestResponses { get; set; }
    }
}