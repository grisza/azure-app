using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AzureApp.Menu.Blob
{
    class Menu : IMenu
    {
        Dictionary<string, IMenu> menuOptions = new Dictionary<string, IMenu>();

        public Menu(IMenu parent, IConfiguration configuration)
        {
            menuOptions.Add("Service properties", new ServicePropertiesItem(this, configuration));
            menuOptions.Add("Create Container", new CeateContainerItem(this, configuration));
            menuOptions.Add("Container metadata", new DisplayContainerMetadataItem(this, configuration));
            menuOptions.Add("List Containers", new ListContainersItem(this, configuration));
            menuOptions.Add("Delete Container", new DeleteContainersItem(this, configuration));

            menuOptions.Add("Add Blob", new AddBlobItem(this, configuration));
            menuOptions.Add("Blob metadata", new DisplayBlobMetadataItem(this, configuration));
            menuOptions.Add("List Blobs", new ListBlobsItem(this, configuration));
            menuOptions.Add("Copy Blob", new CopyBlobItem(this, configuration));
            menuOptions.Add("Delete Blob", new DeleteBlobItem(this, configuration));

            menuOptions.Add("Back to parent menu", parent);
        }

        public async Task Display()
        {
            Console.Clear();
            Console.WriteLine("Selected Endpoint type: Blob");
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