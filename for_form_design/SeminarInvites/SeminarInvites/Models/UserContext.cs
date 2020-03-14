using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeminarInvites.Models
{
    public class UserContext :DbContext
    {
        public UserContext():base("UserContext")
        {

        }
        public DbSet<GuestResponse> Guest { get; set; }
    }
}