using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dashboard_MVC.Extensions;

namespace Dashboard_MVC;

public static class DiConfigs
{
    public static IServiceCollection AddAllServiceExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        // adding application / service layer
        services.ConfigServices();

        // infrastructure / Db
        services.AddDbConnection(configuration);

        return services;
    }
}