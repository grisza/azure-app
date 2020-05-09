using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AzureApp.Menu
{
    abstract class MenuItemBase : IMenu
    {
        protected string StorageConnectionString = "";
        private readonly IMenu _parent;


        protected MenuItemBase(IMenu parent, IConfiguration configuration)
        {
            StorageConnectionString = configuration["appSettings:storageConnectionString"];
            _parent = parent;
        }

        protected abstract Task Execute();

        public async Task Display()
        {
            await Execute();

            Console.WriteLine();
            Console.WriteLine("Press ESC to back to the menu");

            do
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    await _parent.Display();
                    break;
                }
            } while (true);
        }
    }
}
