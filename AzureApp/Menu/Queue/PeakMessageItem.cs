using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Menu.Queue
{
    class PeakMessageItem : MenuItemBase
    {
        public PeakMessageItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {

        }

        protected override async Task Execute()
        {
            Console.Clear();
            Console.WriteLine("-----Peak the message from Queue-----");

            // TODO: get cloud queue connection from the context
            CloudQueue queue = QueueContext.Instance.SelectedCloudQueue;

            // TODO: Peak serialized message
            CloudQueueMessage cloudQueueMessage = await queue.PeekMessageAsync();

            // TODO: deserialize message to the Message object
            Message message = Message.FromJson(cloudQueueMessage.AsString);

            // TODO: display message
            Console.WriteLine();
            Console.WriteLine(message.ToString());
        }
    }
}
