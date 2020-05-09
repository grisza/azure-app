using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Menu.Queue
{
    class CreateAndConnectQueueItem : MenuItemBase
    {
        public CreateAndConnectQueueItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {

        }

        protected override async Task Execute()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            string queueName = "";
            Console.Clear();
            Console.WriteLine("-----Create New Queue-----");
            Console.WriteLine($"New queue name:");
            queueName = Console.ReadLine().ToLower();

            QueueContext.Instance.SelectedCloudQueue = queueClient.GetQueueReference(queueName);
            await QueueContext.Instance.SelectedCloudQueue.CreateIfNotExistsAsync();
                        
            Console.WriteLine("Done!");
        }
    }
}
