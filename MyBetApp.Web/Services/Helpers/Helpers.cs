using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBetApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBetApp.Web.Services.Helpers
{
    public class Helpers : Controller
    {


        private UserManager<ApplicationUser> _userManager;

        //class constructor
       
        public Helpers(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> CurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);

            //var email = user.Email;

            return user.UserName;
        }
    }
}
