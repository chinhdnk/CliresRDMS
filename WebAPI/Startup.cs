using Infrastructure.Entities;
using Infrastructure.Entities.CliresSystem;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using WebAPI.Auth;
using ApplicationCore.Repositories.CiresSystem;
using ApplicationCore.Repositories.CliresSystem;
using Infrastructure.SqlDataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebAPI.Extensions;
using Infrastructure.Services;
using NLog;
using System.IO;

namespace WebAPI
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;
        public IConfiguration configuration { get; set; }
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            this.env = env;
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //*****************************************
            //Run this scipt in PM to update entity from database at Infrastructure project
            //Scaffold-DbContext "Server=(local);Database=CLIRES_SYSTEM;User ID=sa;Password=HappyDay01;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities/CliresSystem -Context CliresSystemDBContext -Force
            //Remove OnConfiguring in CliresSystemDBContext
            //*****************************************

            services.AddDbContext<CliresSystemDBContext>(c =>
            c.UseSqlServer(configuration.GetConnectionString("CliresSystemDB")));

            //*****************************************
            //Configure to connect database by SqlConnection
            //*****************************************
            var sqlConnectionConfig = new SqlConnectionConfiguration(configuration.GetConnectionString("ProjectDB"));
            services.AddSingleton(sqlConnectionConfig);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]))
                };
            });

            services.AddTransient<IJwtTokenManager, JwtTokenManager>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                //options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Web API v1", Version = "version 1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "My Web API v2", Version = "version 2" });
            });

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", opt => opt
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Configure OpenAPI
                app.UseSwagger();
                app.UseSwaggerUI(
                        options => {
                            options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
                        });
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //loggerFactory.AddFile(configuration["LogFile"]);
            app.ConfigureCustomExceptionMiddleware();
            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
