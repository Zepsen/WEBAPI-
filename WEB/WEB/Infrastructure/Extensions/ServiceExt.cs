using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WEB.Infrastructure.Extensions
{
    public static class ServiceExt
    {
        public static void AddInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICompaniesService, CompaniesesService>();
        }
    }
}
