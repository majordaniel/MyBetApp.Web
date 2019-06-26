using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBetApp.Web.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Status { get; set; }
    }
}
