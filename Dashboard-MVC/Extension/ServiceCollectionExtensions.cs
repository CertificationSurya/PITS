using Dashboard_MVC.Services;
using Dashboard_MVC.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard_MVC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}