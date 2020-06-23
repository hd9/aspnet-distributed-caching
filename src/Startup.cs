using AspNetDistributedCaching.Core.Repositories;
using AspNetDistributedCaching.Core.Services;
using AspNetDistributedCaching.Infrastructure.Core.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetDistributedCaching
{
    public class Startup
    {

        readonly AppConfig cfg;
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            cfg = configuration.Get<AppConfig>();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton(cfg.Mongo);
            services.AddTransient<ICatalogRepository, CatalogRepository>();
            services.AddTransient<ICatalogSvc, CatalogSvc>();

            services.AddStackExchangeRedisCache(o =>
            {
                o.Configuration = cfg.Redis.Configuration;
                o.InstanceName = cfg.Redis.InstanceName;
            });

            // allow auto-rebuilding the cshtml after changes (dev-only)
            // https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation?view=aspnetcore-3.1&tabs=visual-studio
#if DEBUG
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
#endif
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
