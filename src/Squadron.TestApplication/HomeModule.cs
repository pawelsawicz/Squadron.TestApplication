using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

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

        public Task GetUsersWithoutDelay(HttpContext httpContext)
        {
            var name = httpContext.GetRouteValue("name");
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            return httpContext.Response.WriteAsync($"Response GetUsersWithoutDelay {name}");
        }

        public Task GetUsersWithRandomDelay(HttpContext httpContext)
        {
            Task.Delay(100);
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            return httpContext.Response.WriteAsync("body");
        }

        public Task PostUserWithRandomDelay(HttpContext httpContext)
        {
            Task.Delay(100);
            var name = httpContext.GetRouteValue("name");
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            return httpContext.Response.WriteAsync($"User : {name} updated");
        }

        public Task PutUserWithRandomDelay(HttpContext httpContext)
        {
            Task.Delay(100);
            httpContext.Response.StatusCode = StatusCodes.Status201Created;
            return httpContext.Response.WriteAsync($"User has been created");
        }
    }
}