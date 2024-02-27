using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Abstract;

namespace Store.DI;

public static class StoreServiceCollectionExtensions
{
    public static void AddStoreServices(this IServiceCollection services, string connectionString)
    {        
        services.AddDbContext<ResourcesContext>(o => o.UseNpgsql(connectionString));

        services.AddScoped<IResourcesContext>(provider => provider.GetRequiredService<ResourcesContext>());
    }
}
