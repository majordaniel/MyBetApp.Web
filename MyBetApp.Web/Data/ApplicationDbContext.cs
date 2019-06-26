using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBetApp.Web.Models;
using System;

namespace MyBetApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Email = "admin@email.com",
                     UserName="admin",
                     PasswordHash="admin123"
                }
                );
        }

      
    }
    /// Do this if you want to create the seed method seperately and also want to seed related data
    /// 

    //public static class ModelBuilderExtensions
    //{
    //    public static void Seed(this ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Author>().HasData(
    //            new Author
    //            {
    //                AuthorId = 1,
    //                FirstName = "William",
    //                LastName = "Shakespeare"
    //            }
    //        );
    //        modelBuilder.Entity<Book>().HasData(
    //            new Book { BookId = 1, AuthorId = 1, Title = "Hamlet" },
    //            new Book { BookId = 2, AuthorId = 1, Title = "King Lear" },
    //            new Book { BookId = 3, AuthorId = 1, Title = "Othello" }
    //        );
    //    }
    //}

    //Then you can call the Seed method in OnModelCreating:

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Seed();
    //}
}
