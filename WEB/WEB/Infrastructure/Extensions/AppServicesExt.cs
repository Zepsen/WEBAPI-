using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WEB.Infrastructure.Extensions
{
    public static class AppServicesExt
    {
        public static void AddAppAuthServices(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = AuthOptions.ISSUER,

                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthOptions.AUDIENCE,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,

                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });
        }

        public static void AddAppIdentityServices(this IServiceCollection services)
        {
            //UserManager
            var builder = services.AddIdentityCore<ApplicationUser>();
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            //RoleManager
            services.AddScoped<IRoleValidator<IdentityRole>, RoleValidator<IdentityRole>>();
            services.AddScoped<RoleManager<IdentityRole>, RoleManager<IdentityRole>>();
        }

        public static void AddAppInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICompaniesService, CompaniesesService>();
        }
    }
}
