using ApplicationCore.Authentication;
using ApplicationCore.Repositories;
using ApplicationCore.Repositories.ApiClient;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AKSoftware.Localization.MultiLanguages;
using System.Globalization;
using ApplicationCore.Services.CliresSystem;
using ApplicationCore.Services.CliresSystem.Admin;

namespace CliresWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddLanguageContainer(Assembly.GetExecutingAssembly());

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddSingleton<AuthenticationStateProvider, JwtTokenAuthenticationStateProvider>();

            builder.Services.AddSingleton<ITokenRepository, TokenRepository>();
            builder.Services.AddSingleton<IWebApiExecuter>(sp =>
                new WebApiExecuter(
                    "https://localhost:44347",//WebAPI
                    new HttpClient(),
                    sp.GetRequiredService<ITokenRepository>()));

            builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

            builder.Services.AddTransient<IPermissionService, PermissionService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IMenuService, MenuService>();

            builder.Services.AddTransient<IProjectsScreenUseCases, ProjectsScreenUseCases>();
            builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
            builder.Services.AddTransient<ITicketRepository, TicketRepository>();
            builder.Services.AddTransient<ITicketsScreenUseCases, TicketsScreenUseCases>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
