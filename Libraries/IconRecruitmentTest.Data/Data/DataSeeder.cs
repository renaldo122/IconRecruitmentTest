using IconRecruitmentTest.Common.Models.DbModels;
using IconRecruitmentTest.Data.IconDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace IconRecruitmentTest.Data.Data
{
    public class DataSeeder
    {
        public static void AddUsers(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (!context.Users.Any())  {
                Users user = new Users()  {
                    Username = "Admin",
                    Email = "admin@gmail.com",
                    IsEnabled = true,
                    CreationTime = DateTime.Now,
                    LastModificationTime = DateTime.Now
                };
                PasswordHasher<Users> passwordHasher = new PasswordHasher<Users>();
                user.Password= passwordHasher.HashPassword(user, "Admin123");
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
