using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBetApp.Web.Models
{
    public class ApplicationDbInitializer
    {

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("oddhandler@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "oddhandler@gmail.com",
                    Email = "oddhandler@gmail.com"
                };

                var result = userManager.CreateAsync(user, "oddhandler123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "OddHandler").Wait();
                }
            }
        }
    }
}
