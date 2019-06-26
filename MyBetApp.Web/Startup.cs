using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyBetApp.Web.Models;
using MyBetApp.Web.Repositories.Abstracts;
using MyBetApp.Web.Repositories.Implementations;

namespace MyBetApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
            services.AddMvc();
            services.AddScoped<IStakes, StakesRepository>();
       
            services.AddDbContext<MyBetAppContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MyBetAppContext>()
                .AddDefaultTokenProviders();



            //services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>()
            //.AddEntityFrameworkStores<MyBetAppContext>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //Password Strength Setting
            //    services.Configure<IdentityOptions>(options =>
            //    {
            //        // Password settings
            //        options.Password.RequireDigit = true;
            //        options.Password.RequiredLength = 8;
            //        options.Password.RequireNonAlphanumeric = false;
            //        options.Password.RequireUppercase = true;
            //        options.Password.RequireLowercase = false;
            //        options.Password.RequiredUniqueChars = 6;

            //        // Lockout settings
            //        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //        options.Lockout.MaxFailedAccessAttempts = 10;
            //        options.Lockout.AllowedForNewUsers = true;

            //        // User settings
            //        options.User.RequireUniqueEmail = true;
            //    });

            //    //Setting the Account Login page
            //    services.ConfigureApplicationCookie(options =>
            //    {
            //        // Cookie settings
            //        options.Cookie.HttpOnly = true;
            //        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            //        options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, 
            //                                              // ASP.NET Core will default to /Account/Login
            //        options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, 
            //                                                // ASP.NET Core will default to /Account/Logout
            //        options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is 
            //                                                            // not set here, ASP.NET Core 
            //                                                            // will default to 
            //                                                            // /Account/AccessDenied
            //        options.SlidingExpiration = true;
            //    });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });

            // CreateUserRoles(service).Wait();
          // ApplicationDbInitializer.SeedUsers(userManager);
        }

        //private async Task CreateUserRoles(IServiceProvider serviceProvider)
        //{
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        //    IdentityResult roleResult;
        //    //Adding Admin Role
        //    var roleCheck = await RoleManager.RoleExistsAsync("Punter");
        //    if (!roleCheck)
        //    {
        //        //create the roles and seed them to the database
        //        roleResult = await RoleManager.CreateAsync(new IdentityRole("Punter"));
        //    }
        //    var role2Check = await RoleManager.RoleExistsAsync("OddHandler");
        //    if (!role2Check)
        //    {
        //        //create the roles and seed them to the database
        //        roleResult = await RoleManager.CreateAsync(new IdentityRole("OddHandler"));
        //    }
        //    var role3Check = await RoleManager.RoleExistsAsync("Admin");
        //    if (!role2Check)
        //    {
        //        //create the roles and seed them to the database
        //        roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
        //    }
        //    //
        //    //Assign Admin role to the main User here we have given our newly registered 
        //    //login id for Admin management
        //    ApplicationUser user = await UserManager.FindByEmailAsync("admin@gmail.com");
        //    var User = new ApplicationUser();
        //    await UserManager.AddToRoleAsync(user, "Admin");

        //    ApplicationUser user2 = await UserManager.FindByEmailAsync("punter@gmail.com");
        //    var User2 = new ApplicationUser();
        //    await UserManager.AddToRoleAsync(user, "Punter");

        //    ApplicationUser user3 = await UserManager.FindByEmailAsync("oddhandler@gmail.com");
        //    var User3 = new ApplicationUser();
        //    await UserManager.AddToRoleAsync(user, "OddHandler");
        //}


    }
}
