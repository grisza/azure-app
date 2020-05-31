using AzureApp.Menu.Table.Entities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Menu.Table
{
    static class TablesHelper
    {
        public static CloudTableClient GetClient(string storageConnectionString)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            return storageAccount.CreateCloudTableClient();
        }

        public static async Task<CloudTable> SelectTable(CloudTableClient tableClient)
        {
            TableResultSegment tables = await DisplayTables(tableClient);

            Console.Write("Selected table: ");
            string itemNumberInput = Console.ReadLine();

            if (int.TryParse(itemNumberInput, out int itemNumber) && itemNumber > 0 && itemNumber < tables.Results.Count() + 1)
            {
                return tables.Results.ElementAt(itemNumber - 1);
            }
            else
            {
                return await SelectTable(tableClient);
            }
        }

        public static async Task<TableResultSegment> DisplayTables(CloudTableClient tableClient)
        {
            Console.WriteLine();
            Console.WriteLine("Tables list:");

            TableResultSegment tables = await tableClient.ListTablesSegmentedAsync(null);
            int counter = 1;

            foreach (var table in tables.Results)
            {
                Console.WriteLine($"{counter++}) {table.Name}");
            }

            return tables;
        }

        public static async Task<UserEntity> SelectEntity(CloudTable cloudTable)
        {
            TableQuerySegment<UserEntity> entities = await DisplayEntities(cloudTable);

            Console.Write("Selected entity: ");
            string itemNumberInput = Console.ReadLine();

            if (int.TryParse(itemNumberInput, out int itemNumber) && itemNumber > 0 && itemNumber < entities.Results.Count() + 1)
            {
                return entities.Results.ElementAt(itemNumber - 1);
            }
            else
            {
                return await SelectEntity(cloudTable);
            }
        }

        public static async Task<TableQuerySegment<UserEntity>> DisplayEntities(CloudTable cloudTable)
        {
            Console.WriteLine();
            Console.WriteLine("Entities list:");

            TableQuery<UserEntity> tableQuery = new TableQuery<UserEntity>();          
            TableQuerySegment<UserEntity> entities = await cloudTable.ExecuteQuerySegmentedAsync(tableQuery, null);
            int counter = 1;

            foreach (var ent in entities.Results)
            {
                Console.WriteLine($"{counter++}) {ent.ToString()}");
            }

            return entities;
        }

    }
}
