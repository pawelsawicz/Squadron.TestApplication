using System;
using Microsoft.AspNetCore.Hosting;

namespace Squadron.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Squadron test application");

            var host = new WebHostBuilder()
            .UseKestrel()
            .UseUrls("http://localhost:5000")
            .UseStartup<Startup>()
            .Build();

            host.Run();
        }
    }
}
