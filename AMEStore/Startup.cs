using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMEStore.Data.Interfaces;
using AMEStore.Data.Mocks;
using Microsoft.Extensions.Configuration;
using AMEStore.Data;
using Microsoft.EntityFrameworkCore;
using AMEStore.Data.Repository;
using AMEStore.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMEStore
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>
               (options =>
               options.UseSqlServer
               (_confString.GetConnectionString("DefaultConnection")
               ));
            services.AddTransient<IProducts, ProductRepository>();
            services.AddTransient<ICategories, CategoryRepository>();
            services.AddTransient<IAllOrders, OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => StoreCart.GetCart(sp) );

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute
                (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute
                (
                    name: "categoryFilter",
                    template: "Product/{action}/{category?}",
                    defaults: new { Controller = "Product", action = "List" }
                );
            });
           
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                DBObjects.Initial(context);
            }
        }
    }
}
