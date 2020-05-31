using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureApp.Menu.Table
{
    internal class ListTablesItem : MenuItemBase
    {
        public ListTablesItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
            // TODO: Implement

            CloudTableClient client = TablesHelper.GetClient(StorageConnectionString);
            await TablesHelper.DisplayTables(client);
        }
    }
}