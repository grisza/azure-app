using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureApp.Menu.Queue
{
    public class Menu : IMenu
    {
        Dictionary<string, IMenu> menuOptions = new Dictionary<string, IMenu>();

        public Menu(IMenu parent, IConfiguration configuration)
        {
            menuOptions.Add("Create new queue and connect to it", new CreateAndConnectQueueItem(this, configuration));
            menuOptions.Add("List existing queues and connect to selected", new ListQueuesAndConnectItem(this, configuration));

            menuOptions.Add("Write message to connected queue", new WriteMessageItem(this, configuration));
            menuOptions.Add("Peak message in the queue", new PeakMessageItem(this, configuration));
            menuOptions.Add("Read message from the queue", new ReadMessageItem(this, configuration));
            menuOptions.Add("Update existing message", new UpdateExistingMessage(this, configuration));

            menuOptions.Add("Back to parent menu", parent);
        }

        public async Task Display()
        {
            Console.Clear();
            Console.WriteLine("Selected Endpoint type: Queue");
            int counter = 1;

            foreach (var menuOption in menuOptions)
            {
                if (counter > 2 && QueueContext.Instance.SelectedCloudQueue == null)
                {
                    continue;
                }

                Console.WriteLine($"{counter++}) {menuOption.Key}");
            }

            Console.WriteLine();
            Console.Write("Selected option: ");
            string itemNumberInput = Console.ReadLine();

            if (int.TryParse(itemNumberInput, out int itemNumber) && itemNumber > 0 && itemNumber < menuOptions.Count + 1)
            {
                if (itemNumber > 2 && itemNumber < menuOptions.Count && QueueContext.Instance.SelectedCloudQueue == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("You must connect to the queue first");
                    Thread.Sleep(2000);
                    await Display();
                }
                else
                {
                    var option = menuOptions.ElementAt(itemNumber - 1);
                    await option.Value.Display();
                }
            }
        }
    }
}
