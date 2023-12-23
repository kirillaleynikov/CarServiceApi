using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CarService.Context
{
    /// <summary>
    /// Файбрика для создания контекста в DesignTime (Миграции)
    /// </summary>
    public class SampleContextFactory : IDesignTimeDbContextFactory<CarServiceContext>
    {
        public CarServiceContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<CarServiceContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new CarServiceContext(options);
        }
    }
}
