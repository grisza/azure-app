using System;
using System.Reflection;
using System.Threading.Tasks;
using AzureApp.Menu.Table.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureApp.Menu.Table
{
    internal class AddEntityItem : MenuItemBase
    {
        public AddEntityItem(IMenu menu, IConfiguration configuration) : base(menu, configuration)
        {
        }

        protected override async Task Execute()
        {
            // TODO: Implement
            CloudTableClient client = TablesHelper.GetClient(StorageConnectionString);
            CloudTable table = await TablesHelper.SelectTable(client);

            Console.WriteLine();
            Console.WriteLine("Name:" );
            string name = Console.ReadLine();
            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Age:");
            string age = Console.ReadLine();

            UserEntity entity = new UserEntity(lastName, name, int.Parse(age));

            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);
            await table.ExecuteAsync(insertOrMergeOperation);
        }
    }
}