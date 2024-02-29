using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Store.Migrations;

internal class ResourcesContextDesignTimeFactory : IDesignTimeDbContextFactory<ResourcesContext>
{
    private const string _fileName = "appsettings.Development.json";
    public ResourcesContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ResourcesContext>();

        var configurationBuilde = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(_fileName)
            .Build();

        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings_Default")
                            ?? configurationBuilde.GetConnectionString("Default")
                            ?? throw new ArgumentNullException("Connection string is empty");

        optionsBuilder
            .UseNpgsql(connectionString);

        return new ResourcesContext(optionsBuilder.Options);
    }
}
