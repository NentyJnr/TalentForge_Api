using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TalentForge.Persistence
{
    public class TalentForgeDbContextFactory : IDesignTimeDbContextFactory<TalentForgeDbContext>
    {
        public TalentForgeDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TalentForgeDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("TalentForgeConnectionString"));

            return new TalentForgeDbContext(optionsBuilder.Options);
        }
    }
}