using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureApp.Menu.Table
{
    internal class ListEntitiesItem : MenuItemBase
    {
        public ListEntitiesItem(IMenu menu, IConfiguration configuration) : base(menu, configuration)
        {
        }

        protected override async Task Execute()
        {
            // TODO: Implement

            CloudTableClient client = TablesHelper.GetClient(StorageConnectionString);
            CloudTable table = await TablesHelper.SelectTable(client);
            await TablesHelper.DisplayEntities(table);
        }
    }
}