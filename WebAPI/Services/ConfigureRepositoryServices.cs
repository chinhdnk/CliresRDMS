using ApplicationCore.Repositories.Account;
using ApplicationCore.Repositories.CliresSystem;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Auth;

namespace WebAPI.Services
{
    public static class ConfigureRepositoryServices
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {

            services.AddTransient<IJwtTokenManager, JwtTokenManager>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            return services;
        }
    }
}
