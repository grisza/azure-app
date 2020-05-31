using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Menu.Queue
{
    static class QueueHelper
    {
        public static CloudQueueClient GetClient(string storageConnectionString)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            return storageAccount.CreateCloudQueueClient();
        }

        public static async Task<QueueResultSegment> DisplayQueues(CloudQueueClient queueClient)
        {
            Console.WriteLine();
            Console.WriteLine("Queues list:");

            QueueResultSegment queues = await queueClient.ListQueuesSegmentedAsync(null);
            int counter = 1;

            foreach (var queue in queues.Results)
            {
                Console.WriteLine($"{counter++}) {queue.Name}");
            }

            return queues;
        }

        public static async Task<CloudQueue> SelectQueue(CloudQueueClient queueClient)
        {
            QueueResultSegment queues = await DisplayQueues(queueClient);

            Console.Write("Selected queue: ");
            string itemNumberInput = Console.ReadLine();

            if (int.TryParse(itemNumberInput, out int itemNumber) && itemNumber > 0 && itemNumber < queues.Results.Count() + 1)
            {
                return queues.Results.ElementAt(itemNumber - 1);
            }
            else
            {
                return await SelectQueue(queueClient);
            }
        }
    }
}
