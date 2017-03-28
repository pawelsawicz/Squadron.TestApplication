using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Squadron.TestApplication
{
    public class HomeModule
    {
        public Task CheckVersion(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            return httpContext.Response.WriteAsync("1.0.0");
        }

        public Task CheckHealthz(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            return Task.FromResult(httpContext);
        }

        public Task GetUsersWithRandomDelay(HttpContext httpContext)
        {
            Task.Delay(100);
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            return httpContext.Response.WriteAsync("body");
        }        
    }
}