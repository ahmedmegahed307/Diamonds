using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Jewellery.BL;
using Jewellery.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
//using Jewellery.DataTimeOffSet;

using Jewellery.Data;
using ReflectionIT.Mvc.Paging;
using Jewellery.InfraStructure;

namespace Jewellery
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<JewelContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Jewels")));

            services.AddControllersWithViews();
            services.AddScoped<IProductService, ClsProduct>();
            services.AddScoped<ICategorySerivce, ClsCategory>();
            services.AddMvc();
            services.AddSession( Options=>
            {
                Options.IdleTimeout = TimeSpan.FromDays(2);
            });
            //services.AddPaging();
            services.AddHttpContextAccessor();//access session in classes not controllers(Dependency Injection)
            services.AddDistributedMemoryCache();
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
               .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            //language
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                     new CultureInfo("ar-EG"),
                      new CultureInfo("tr"),


                };
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

            }
            //*language

            );
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();//for api
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            var localoption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localoption.Value);

            app.UseAuthentication();
            app.UseAuthorization();
         


            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
             name: "MyArea",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   "Home",
                   "Home/{categorySlug}",
                   defaults: new { controller = "Home", action = "ProductsByCategory" }
               );

                endpoints.MapControllerRoute(
             name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

            });
            //for api
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
             
        }
    }
}
