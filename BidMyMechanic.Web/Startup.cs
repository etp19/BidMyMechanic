using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BidMyMechanic.Entities;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.Repositories.Interfaces;
using BidMyMechanic.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using BidMyMechanic.Services.Interfaces;
using BidMyMechanic.Services.Services;
using BidMyMechanic.ViewModels.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace BidMyMechanic.Web
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Identity Configuration
            services.AddIdentityCore<BidUser>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<BidMyMechanicContext>()
                .AddSignInManager<SignInManager<BidUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Tokens:Issuer"],
                        ValidAudience = _config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                    };
                });

            // db config and connection string
            services.AddDbContext<BidMyMechanicContext>(db => 
            {
                db.UseSqlServer(_config.GetConnectionString("BidMyMechanicConnectionStringLocal"));
            });

            // Seeder
            services.AddTransient<BidMyMechanicSeeder>();

            // AutoMapper Configuration
            services.AddAutoMapper(typeof(BaseMappingProfile));

            // Services
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IIssueTrackingService, IssueTrackingService>();

            //Repositories
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IBidService, BidService>();

            // Configurations
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg => {
                cfg.MapControllerRoute("Default",
                    "{controller}/{action}/{id?}",
                    new { controller = "Bid", Action = "Index" });
            });
        }
    }
}
