using System;
using System.Threading.Tasks;
using AzureApp.Menu.Table.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureApp.Menu.Table
{
    internal class DeleteEntityItem : MenuItemBase
    {
        public DeleteEntityItem(IMenu menu, IConfiguration configuration) : base(menu, configuration)
        {
        }

        protected override async Task Execute()
        {
            // TODO: Implement
            CloudTableClient client = TablesHelper.GetClient(StorageConnectionString);
            CloudTable table = await TablesHelper.SelectTable(client);
            UserEntity userEntity = await TablesHelper.SelectEntity(table);

            await table.ExecuteAsync(TableOperation.Delete(userEntity));
        }
    }
}