using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace aaa.Data
{
    public static class ContextSeed
    {
        private static List<IdentityRole> RolesList()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole() {
                    Id=new Guid("ed58a605-7838-4105-9ceb-f0a59d69256a").ToString()  ,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole() {
                      Id=new Guid("ed58a605-7838-4107-9ceb-f0a59d69256a").ToString()  ,
                      NormalizedName = "USER",
                      Name = "User"
                }
            };
        }

        private static List<IdentityUser> UsersList()
        {
            return new List<IdentityUser>()
            {
                //new IdentityUser() {
                //    Id=new Guid("ed58a605-7838-4101-9ceb-f0a59d69256a").ToString() ,
                //    UserName= "Admin",
                //    NormalizedUserName = "ADMIN",
                //    EmailConfirmed = true,
                //    PasswordHash="AQAAAAEAACcQAAAAEG6r5lwpq4+94Yil5IdwrcQwgPlIauHvK9xPBqprWA/Ydpgjj/amT8cqUlajYPZAwA==",//password=Admin*123
                //    Email="administrator@aaa.com",
                //    NormalizedEmail = "ADMINISTRATOR@AAA.COM"
                //}
            };
        }

        private static void CreateRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(RolesList());
        }

        private static void CreateUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().HasData(UsersList());
        }

       
        /// <summary>
        /// This is extension method to add data in the database
        /// </summary>
        public static void UsersAndRolesCreate(this ModelBuilder modelBuilder)
        {
            CreateRoles(modelBuilder);
            CreateUsers(modelBuilder);
        }
    }
}
