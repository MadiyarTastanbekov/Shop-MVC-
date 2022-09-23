using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repository;
using Shop.Data.Models;

namespace Shop
{
    public class Startup
    {
        private IConfigurationRoot _configuration;
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _configuration = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath).AddJsonFile("dbsettings.json").Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRipository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                  name: "categoryFilter", pattern: "Cars/{action}/{category?}", defaults: new { Controller = "Cars", action = "ListView" });
            });
            {
                using var scope = app.ApplicationServices.CreateScope();
                AppDbContext appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbObjects.Initial(appDbContext);
            }
            
          
        }
    }
}
