using ApplicationCore.Authentication;
using ApplicationCore.Repositories.ApiClient;
using CliresWeb;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CliresSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

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


            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
