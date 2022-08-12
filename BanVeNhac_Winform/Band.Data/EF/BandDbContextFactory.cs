using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Band.Data.EF
{
    public class BandDbContextFactory : IDesignTimeDbContextFactory<BandDbContext>
    {
        public BandDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("bandDb");

            var optionsBuilder = new DbContextOptionsBuilder<BandDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new BandDbContext(optionsBuilder.Options);
        }
    }
}
