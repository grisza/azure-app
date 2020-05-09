using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AzureApp.Menu.Table
{
    internal class DeleteTableItem : MenuItemBase
    {
        public DeleteTableItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
            // TODO: Implement


            throw new NotImplementedException();
        }
    }
}