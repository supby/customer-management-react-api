using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementReactWebAPI.Interfaces.Persistence;
using CustomerManagementReactWebAPI.Interfaces.Services;
using CustomerManagementReactWebAPI.Models.Entity;
using CustomerManagementReactWebAPI.Persistence;
using CustomerManagementReactWebAPI.Persistence.Repositories;
using CustomerManagementReactWebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomerManagementReactWebAPI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // TODO: probably it worth to move out boostrap to separate project
            // and Web will have only references to Interfaces

            services.AddDbContext<CustomerDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("CustomerDB")));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<IRepository<Customer>, RepositoryBase<Customer>>();

            services.AddScoped<ICustomerService, CustomerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
