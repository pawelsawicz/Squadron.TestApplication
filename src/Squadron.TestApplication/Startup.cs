using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Squadron.TestApplication
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            this.SetupRoutes(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        private void SetupRoutes(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapGet("version", context =>
            {
                var homeModule = new HomeModule();
                return homeModule.CheckVersion(context);
            });

            routeBuilder.MapGet("healthz", context =>
            {
                var homeModule = new HomeModule();
                return homeModule.CheckHealthz(context);
            });

            routeBuilder.MapGet("users", context =>
            {
                var homeModule = new HomeModule();
                return homeModule.GetUsersWithRandomDelay(context);
            });

            var routes = routeBuilder.Build();
            app.UseRouter(routes);
        }
    }
}