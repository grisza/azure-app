using Microsoft.Extensions.Configuration;
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
            // TODO: get message body form console
            // TODO: create Message object with user's provided data
            // TODO: Serialize Message to JSON format
            // TODO: Wrap JSON with CloudQueueMessage object
            // TODO: Add CloudQueueMessage object to the queue context

            throw new NotImplementedException();
        }
    }
}
