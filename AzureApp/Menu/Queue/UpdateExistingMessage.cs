using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Menu.Queue
{
    class UpdateExistingMessage : MenuItemBase
    {
        public UpdateExistingMessage(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {

        }

        protected override async Task Execute()
        {
            Console.Clear();
            Console.WriteLine("-----Update existing message in Queue-----");

            // TODO: Get the message from the selected queue context
            CloudQueue queue = QueueContext.Instance.SelectedCloudQueue;
            CloudQueueMessage cloudQueueMessage = await queue.GetMessageAsync();

            // TODO: Set new content on the selected message
            Message message = Message.FromJson(cloudQueueMessage.AsString);
            message.Body += "-- Content updated";
            cloudQueueMessage.SetMessageContent(message.ToJson());

            // TODO: Update message on the queue context
            await queue.UpdateMessageAsync(
                cloudQueueMessage,
                TimeSpan.Zero,
                MessageUpdateFields.Content |
                MessageUpdateFields.Visibility);
        }
    }
}
