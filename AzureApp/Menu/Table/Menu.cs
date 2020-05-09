using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AzureApp.Menu.Table
{
    class Menu : IMenu
    {
        Dictionary<string, IMenu> menuOptions = new Dictionary<string, IMenu>();

        public Menu(IMenu parent, IConfiguration configuration)
        {
            menuOptions.Add("Create table", new CeateTableItem(this, configuration));
            menuOptions.Add("Delete table", new DeleteTableItem(this, configuration));
            menuOptions.Add("List tables", new ListTablesItem(this, configuration));

            menuOptions.Add("Add entity", new AddEntityItem((IMenu)this, configuration));
            menuOptions.Add("Replace entity", new ReplaceEntityItem((IMenu)this, configuration));
            menuOptions.Add("Update entity", new UpdateItem((IMenu)this, configuration));
            menuOptions.Add("Delete entity", new DeleteEntityItem((IMenu)this, configuration));
            menuOptions.Add("List entities", new ListEntitiesItem((IMenu)this, configuration));

            menuOptions.Add("Back to parent menu", parent);
        }

        public async Task Display()
        {
            Console.Clear();
            Console.WriteLine("Selected Endpoint type: Tables");
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
