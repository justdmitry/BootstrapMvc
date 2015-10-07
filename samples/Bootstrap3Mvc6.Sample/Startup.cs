using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using BootstrapMvc;
using Microsoft.Framework.Logging;

namespace Bootstrap3Mvc6.Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient(typeof(BootstrapMvc.Mvc6.BootstrapHelper<>));
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Verbose;
            loggerFactory.AddConsole();

            app.UseStatusCodePages();
            app.UseErrorPage();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "controllerActionRoute",
                    "{controller}/{action}",
                    new { controller = "Home", action = "Index" },
                    constraints: null,
                    dataTokens: new { NameSpace = "default" });

                routes.MapRoute(
                    "controllerRoute",
                    "{controller}",
                    new { controller = "Home" });
            });
        }
    }
}
