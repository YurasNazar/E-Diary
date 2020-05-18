using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}
