using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureApp.Menu.Blob
{
    internal class DisplayContainerMetadataItem : MenuItemBase
    {
        public DisplayContainerMetadataItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            string blobPath = "";
            Console.Clear();
            Console.WriteLine("-----Container Metadata-----");
            
            Console.WriteLine($"Containers list:");

            ContainerResultSegment containers = await blobClient.ListContainersSegmentedAsync(null);
            int counter = 1;

            foreach (var container in containers.Results)
            {
                Console.WriteLine($"{counter++}) {container.Name}");
            }

            Console.Write("Selected container: ");
            string itemNumberInput = Console.ReadLine();

            if (int.TryParse(itemNumberInput, out int itemNumber) && itemNumber > 0 && itemNumber < containers.Results.Count() + 1)
            {
                var selectedContainer = containers.Results.ElementAt(itemNumber - 1);
                Console.WriteLine();
                Console.WriteLine("Selected container metadata:");

                foreach (var metadata in selectedContainer.Metadata)
                {
                    Console.WriteLine($"{metadata.Key} - {metadata.Value}");
                }
            }
        }
    }
}