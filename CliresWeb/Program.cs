using ApplicationCore.Repositories;
using ApplicationCore.Repositories.ApiClient;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AKSoftware.Localization.MultiLanguages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using CliresWeb.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace CliresWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                });

            builder.Services.AddLanguageContainer(Assembly.GetExecutingAssembly());

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddHttpClient("WebApi", (sp, cl) =>
            {
                cl.BaseAddress = new Uri("https://localhost:44347");
                cl.EnableIntercept(sp);
            });

            builder.Services.AddScoped(
                sp => sp.GetService<IHttpClientFactory>().CreateClient("WebApi"));

            builder.Services.AddHttpClientInterceptor();

            //add Clires web's services
            builder.Services.AddWebServices();

            await builder.Build().RunAsync();
        }
    }
}
