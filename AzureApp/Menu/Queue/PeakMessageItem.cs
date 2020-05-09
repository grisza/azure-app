using Microsoft.Extensions.Configuration;
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
            // TODO: Peak serialized message
            // TODO: deserialize message to the Message object
            // TODO: display message

            throw new NotImplementedException();
        }
    }
}
