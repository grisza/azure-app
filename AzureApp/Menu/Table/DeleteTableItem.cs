using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;

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
            CloudTableClient client = TablesHelper.GetClient(StorageConnectionString);
            CloudTable table = await TablesHelper.SelectTable(client);
            await table.DeleteIfExistsAsync();
        }
    }
}