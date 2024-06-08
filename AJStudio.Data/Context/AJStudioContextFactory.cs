using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AJStudio.Data.Context
{
    public class AJStudioContextFactory : IDesignTimeDbContextFactory<AJStudioContext>
    {
        public AJStudioContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AJStudioContext>();

            // Load configuration from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(@"D:\Aakash Studio\AJStudio.Web\AJStudio.Api\")
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("dbcs");
            optionsBuilder.UseSqlServer(connectionString);

            return new AJStudioContext(optionsBuilder.Options);
        }
    }
}
