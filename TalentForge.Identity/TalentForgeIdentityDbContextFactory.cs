using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Identity;

namespace TalentForge.Identity
{
    public class TalentForgeIdentityDbContextFactory : IDesignTimeDbContextFactory<TalentForgeIdentityDbContext>
    {
        public TalentForgeIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "TalentForge.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TalentForgeIdentityDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("TalentForgeIdentityConnectionString"));

            return new TalentForgeIdentityDbContext(optionsBuilder.Options);
        }
    }

    //public class TalentForgeIdentityDbContextFactory : IDesignTimeDbContextFactory<TalentForgeIdentityDbContext>
    //{
    //    public TalentForgeIdentityDbContext CreateDbContext(string[] args)
    //    {
    //        var builder = new DbContextOptionsBuilder<TalentForgeIdentityDbContext>();
    //        builder.UseSqlServer("YourActualConnectionString");

    //        return new TalentForgeIdentityDbContext(builder.Options);
    //    }
    //}
}