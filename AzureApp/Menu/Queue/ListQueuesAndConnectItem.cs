using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Menu.Queue
{
    class ListQueuesAndConnectItem : MenuItemBase
    {
        public ListQueuesAndConnectItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {

        }

        protected override async Task Execute()
        {
            Console.Clear();
            Console.WriteLine("-----List queues and connect to selected Queue-----");

            //TODO: Create cloud queue client
            CloudQueueClient queueClient = QueueHelper.GetClient(StorageConnectionString);
            //TODO: List existing queues
            CloudQueue queue = await QueueHelper.SelectQueue(queueClient);

            //TODO: Assign selected queue to the context
            QueueContext.Instance.SelectedCloudQueue = queue;
        }
    }
}
