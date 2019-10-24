using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BidMyMechanic.Entities;
using BidMyMechanic.Repositories.Interfaces;
using BidMyMechanic.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using BidMyMechanic.Services.Interfaces;
using BidMyMechanic.Services.Services;
using BidMyMechanic.ViewModels.Mappings;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Default",
                      "{controller}/{action}/{id?}",
                      new { controller = "Bid", Action = "Index" });
            });
        }
    }
}
