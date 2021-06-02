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
using Infrastructure.Repositories.CiresSystem;
using Infrastructure.Repositories.CliresSystem;
using Infrastructure.SqlDataAccess;

namespace WebAPI
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            this._env = env;
            this.Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<BugsDBContext>(options =>
            {
                options.UseInMemoryDatabase("Bugs");
            });

            //Run this scipt in PM to update entity from database at Infrastructure project
            //Scaffold-DbContext "Server=(local);Database=CLIRES_SYSTEM;User ID=sa;Password=HappyDay01;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities/CliresSystem -Context CliresSystemDBContext -Force
            services.AddDbContext<CliresSystemDBContext>(c =>
            c.UseSqlServer(Configuration.GetConnectionString("CliresSystemDB")));

            var sqlConnectionConfig = new SqlConnectionConfiguration(Configuration.GetConnectionString("ProjectDB"));
            services.AddSingleton(sqlConnectionConfig);

            services.AddControllers();
            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", 
                options => { 
                    options.Authority = "https://localhost:5001";  //TODO: need to configure
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
            services.AddTransient<IJwtTokenManager, JwtTokenManager>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

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
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://localhost:44323") //CliresWeb
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                    //.SetIsOriginAllowed(origin => true) // allow any origin
                    //.AllowCredentials(); // allow credentials
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BugsDBContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Create the in-memory database for dev environment
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //Configure OpenAPI
                app.UseSwagger();
                app.UseSwaggerUI(
                        options => {
                            options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
                            options.SwaggerEndpoint("/swagger/v2/swagger.json", "WebAPI v2");
                        });
            }

            app.UseCors();
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
