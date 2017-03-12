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
    }
}