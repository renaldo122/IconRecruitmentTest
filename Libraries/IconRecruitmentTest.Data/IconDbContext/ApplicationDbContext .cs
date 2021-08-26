using System.IO;
using IconRecruitmentTest.Common.Models.DbModels;
using IconRecruitmentTest.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace IconRecruitmentTest.Data.IconDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ShippingData> ShippingData { get; set; }
        public virtual DbSet<Users> Users { get; set; }


    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetSection("ConnectionStrings:Default").Value;
            builder.UseSqlServer(connectionString);

            var appContext = new ApplicationDbContext(builder.Options);
            DataSeeder.AddUsers(new ApplicationDbContext(builder.Options));

            return appContext;
        }
        
    }
}
