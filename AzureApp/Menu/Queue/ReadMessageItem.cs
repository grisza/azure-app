using Microsoft.Extensions.Configuration;
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
            // TODO: get serialized message
            // TODO: deserialize message to the Message object
            // TODO: display message
            // TODO: display queue message data as well

            throw new NotImplementedException();
        }
    }
}
