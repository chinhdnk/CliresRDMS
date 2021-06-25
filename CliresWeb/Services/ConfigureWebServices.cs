using ApplicationCore.Repositories;
using ApplicationCore.Repositories.Account;
using ApplicationCore.Repositories.ApiClient;
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
            services.AddScoped<HttpInterceptorService>();
            services.AddScoped<IWebApiExecuter, WebApiExecuter>();
            //Clires system services
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IDynamicDBService, DynamicDBService>();


            return services;
        }
    }
}
