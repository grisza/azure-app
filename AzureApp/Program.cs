using System;
using System.IO;
using AzureApp.Menu;
using Microsoft.Extensions.Configuration;

namespace AzureApp
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            MainMenu mainMenu = new MainMenu(Configuration);
            mainMenu.Display().Wait();
        }
    }
}