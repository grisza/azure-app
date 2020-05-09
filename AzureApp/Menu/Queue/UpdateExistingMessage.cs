using Microsoft.Extensions.Configuration;
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
            // TODO: Set new content on the selected message
            // TODO: Update message on the queue context
            

            throw new NotImplementedException();
        }
    }
}
