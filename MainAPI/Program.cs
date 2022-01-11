using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MainAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //production
                  //  webBuilder.UseIISIntegration();
                  // webBuilder.UseKestrel();
                   /// webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    
                    //production

                    webBuilder.UseStartup<Startup>();
                });
    }
}
