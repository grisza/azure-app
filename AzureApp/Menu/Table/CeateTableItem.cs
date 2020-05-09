using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureApp.Menu.Table
{
    internal class CeateTableItem : MenuItemBase
    {
        public CeateTableItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            string tableName = "";
            Console.Clear();
            Console.WriteLine("-----Create Table-----");
            Console.WriteLine($"New table name:");
            tableName = Console.ReadLine().ToLower();

            CloudTable table = tableClient.GetTableReference(tableName);

            await table.CreateIfNotExistsAsync();
            Console.WriteLine("Done!");
        }
    }
}