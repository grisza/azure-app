using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace AzureApp.Menu
{
    class MainMenu : IMenu
    {
        Dictionary<string, IMenu> menuOptions = new Dictionary<string, IMenu>();

        public MainMenu(IConfiguration configuration)
        {
            menuOptions.Add("Blob", new Blob.Menu(this, configuration));
            menuOptions.Add("Table", new Table.Menu(this, configuration));
            menuOptions.Add("Queue", new Queue.Menu(this, configuration));
        }

        public async Task Display()
        {
            Console.Clear();
            int counter = 1;

            foreach (var menuOption in menuOptions)
            {
                Console.WriteLine($"{counter++}) {menuOption.Key}");
            }

            Console.WriteLine();
            Console.Write("Selected option: ");
            string itemNumberInput = Console.ReadLine();

            if (int.TryParse(itemNumberInput, out int itemNumber) && itemNumber > 0 && itemNumber < menuOptions.Count + 1)
            {
                var option = menuOptions.ElementAt(itemNumber - 1);
                await option.Value.Display();
            }
        }
    }
}