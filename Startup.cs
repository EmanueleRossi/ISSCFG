using System;
using System.Globalization;
using System.IO;
using ISSCFG.Models.Services;
using ISSCFG.Models.Services.API;
using ISSCFG.Models.Services.Application;
using ISSCFG.Models.Services.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ISSCFG
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
            services.Configure<RequestLocalizationOptions>(opts =>
                {
                    var supportedCultures = new[]
                    {
                        new CultureInfo("de-DE"),
                        new CultureInfo("it-IT"),
                        new CultureInfo("en-US"),                        
                    };
                    opts.DefaultRequestCulture = new RequestCulture("en-US");
                    opts.SupportedCultures = supportedCultures;
                    opts.SupportedUICultures = supportedCultures;
                });
            services.AddLocalization();                

            services.AddControllersWithViews().AddViewLocalization();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();                
            });
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IUserInputService, UserInputService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IConfigurator, MeetingRoomConfigurator>();
            services.AddTransient<IIpGeoLocation, IpGeoLocation>();

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AppConnectionString")));         
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {           
                app.UseDeveloperExceptionPage();
                lifetime.ApplicationStarted.Register(() =>
                {
                    string filePath = Path.Combine(env.ContentRootPath, "bin/reload.txt");
                    File.WriteAllText(filePath, DateTime.Now.ToString());
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for Itemion scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseForwardedHeaders();
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
