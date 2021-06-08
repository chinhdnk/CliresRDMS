using ApplicationCore.Repositories;
using ApplicationCore.Services;
using ApplicationCore.Services.Account;
using ApplicationCore.Services.CliresSystem;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace CliresWeb.Services
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenRepository, TokenRepository>();
            services.AddSingleton<AuthenticationStateProvider, JwtTokenAuthenticationStateProvider>();
            services.AddTransient<IAccountService, AccountService>();

            //Clires system services
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IMenuService, MenuService>();

            return services;
        }
    }
}
