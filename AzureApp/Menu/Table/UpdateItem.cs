using System;
using System.Threading.Tasks;
using AzureApp.Menu.Table.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureApp.Menu.Table
{
    internal class UpdateItem : MenuItemBase
    {
        public UpdateItem(IMenu menu, IConfiguration configuration) : base(menu, configuration)
        {
        }

        protected override async Task Execute()
        {
            // TODO: Implement
            CloudTableClient client = TablesHelper.GetClient(StorageConnectionString);
            CloudTable table = await TablesHelper.SelectTable(client);
            UserEntity userEntity = await TablesHelper.SelectEntity(table);
            ExtendedUserEntity extended = new ExtendedUserEntity(userEntity, "some value");
           
            await table.ExecuteAsync(TableOperation.InsertOrMerge(extended));
        }

        class ExtendedUserEntity : TableEntity
        {
            public ExtendedUserEntity(UserEntity userEntity, string someField)
            {
                base.PartitionKey = userEntity.PartitionKey;
                base.RowKey = userEntity.RowKey;

                this.SomeField = someField;
            }

            public string SomeField { get; set; }
        }
    }

   
}