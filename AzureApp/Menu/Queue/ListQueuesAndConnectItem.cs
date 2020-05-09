using Microsoft.Extensions.Configuration;
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
            //TODO: List existing queues
            //TODO: Assign selected queue to the context

            throw new NotImplementedException();
        }
    }
}
