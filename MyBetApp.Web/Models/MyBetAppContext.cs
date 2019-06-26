
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyBetApp.Web.Models
{
    public partial class MyBetAppContext : IdentityDbContext<ApplicationUser>
    {
        public MyBetAppContext()
        {
        }

        public MyBetAppContext(DbContextOptions<MyBetAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbOdds> TbOdds { get; set; }

        public virtual DbSet<TbStakes> TbStakes { get; set; }
        public virtual DbSet<TbStakeDetails> TbStakeDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\danielsqlserver;Database=MyBetApp;user id=sa;password=admin123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //-------------for identity------------

            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


            //var hasher = new PasswordHasher<ApplicationUser>();
            //var PasswordHash = hasher.HashPassword(null, "SOME_ADMIN_PLAIN_PASSWORD");

            //------------------------------------------------------

            //modelBuilder.Entity<ApplicationUser>().HasData(


            //new ApplicationUser
            //    {
            //        Email = "admin@gmail.com",
            //        UserName = "admin",
            //        //PasswordHash = "Admin@123",
            //        PasswordHash = "AQAAAAEAACcQAAAAEDF1tc/j6dMMjsQ79WY/3y+iRkGN7cKZdQ4WpNpkJnXRT9h61/v/rrNgXTDhU2EoGg==",

            //    },
            //      new ApplicationUser
            //      {
            //          Email = "punter@gmail.com",
            //          UserName = "punter",
            //          PasswordHash = "AQAAAAEAACcQAAAAEGqlS5TwBubk9ZOT7qd0ubnW91DSFh5YBrO1hyo6gyEE8L2tehTXGCqInsYwoTiNtQ ==", //"Punter@123"


            //      },
            //        new ApplicationUser
            //        {
            //            Email = "oddhandler@gmail.com",
            //            UserName = "oddhandler",
            //            PasswordHash = "AQAAAAEAACcQAAAAEGKP6YzkPqhs4svsfkPoEcRkplW+ARnMf35plpIUuMe60DLdQKElU24rImL/SCr2tQ==", //Oddhandler@123


            //        }
            //    );

            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Punter", NormalizedName = "Punter".ToUpper() });
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "OddHandler", NormalizedName = "OddHandler".ToUpper() });


            // any guid
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ADMIN_ID2 = "a18be9c0-aa65-4af8-bd17-00bd9344e576";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;
            const string ROLE_ID2 = ADMIN_ID2;

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "oddhandler",
                NormalizedName = "oddhandler"
            },
            new IdentityRole
            {
                Id = ROLE_ID2,
                Name = "punter",
                NormalizedName = "punter"
            }

            );


            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "oddhandler",
                NormalizedUserName = "oddhandler",
                Email = "oddhandler@gmail.com",
                NormalizedEmail = "oddhandler@gmail.com",
                EmailConfirmed = true,
                //PasswordHash = hasher.HashPassword(null, "Oddhandler@123"),
                PasswordHash = "AQAAAAEAACcQAAAAEGKP6YzkPqhs4svsfkPoEcRkplW+ARnMf35plpIUuMe60DLdQKElU24rImL/SCr2tQ==",

                SecurityStamp = string.Empty
            },

            new ApplicationUser
            {
                Id = ADMIN_ID2,
                UserName = "punter",
                NormalizedUserName = "punter",
                Email = "punter@gmail.com",
                NormalizedEmail = "punter@gmail.com",
                EmailConfirmed = true,
                //PasswordHash = hasher.HashPassword(null, "Punter@123"),
                PasswordHash = "AQAAAAEAACcQAAAAEGqlS5TwBubk9ZOT7qd0ubnW91DSFh5YBrO1hyo6gyEE8L2tehTXGCqInsYwoTiNtQ==",
                SecurityStamp = string.Empty
            }

            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            },
            new IdentityUserRole<string>
            {
                RoleId = ROLE_ID2,
                UserId = ADMIN_ID2
            }
            );


        }

    }
}
