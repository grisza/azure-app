using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Menu.Queue
{
    class ReadMessageItem : MenuItemBase
    {
        public ReadMessageItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {

        }

        protected override async Task Execute()
        {
            Console.Clear();
            Console.WriteLine("-----Read message from Queue-----");

            // TODO: get cloud queue connection from the context
            CloudQueue queue = QueueContext.Instance.SelectedCloudQueue;

            // TODO: get serialized message
            CloudQueueMessage cloudQueueMessage = await queue.GetMessageAsync();

            // TODO: deserialize message to the Message object
            Message message = Message.FromJson(cloudQueueMessage.AsString);

            // TODO: display message
            Console.WriteLine();
            Console.WriteLine(message.ToString());

            // TODO: display queue message data as well
            Console.WriteLine();
            Console.WriteLine(cloudQueueMessage.ToString());

            await queue.DeleteMessageAsync(cloudQueueMessage);
        }
    }
}
