using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Menu.Queue
{
    class WriteMessageItem : MenuItemBase
    {
        public WriteMessageItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {

        }

        protected override async Task Execute()
        {
            Console.Clear();
            Console.WriteLine("-----Write new messege Queue-----");

            // TODO: get user name from console
            Console.WriteLine();
            Console.WriteLine("Give username:");
            string sender = Console.ReadLine();

            // TODO: get message body form console
            Console.WriteLine();
            Console.WriteLine("Message:");
            string body = Console.ReadLine();

            // TODO: create Message object with user's provided data
            Message message = new Message(sender, body);

            // TODO: Serialize Message to JSON format
            string serializedMessage = message.ToJson();

            // TODO: Wrap JSON with CloudQueueMessage object
            CloudQueueMessage cloudQueueMessage = new CloudQueueMessage(serializedMessage);

            // TODO: Add CloudQueueMessage object to the queue context
            await QueueContext.Instance.SelectedCloudQueue.AddMessageAsync(cloudQueueMessage);
        }
    }
}
