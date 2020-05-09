using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureApp.Menu.Blob
{
    internal class ListContainersItem : MenuItemBase
    {
        public ListContainersItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            Console.Clear();
            Console.WriteLine("-----List of containers-----");
            Console.WriteLine($"Containers list:");

            ContainerResultSegment containers = await blobClient.ListContainersSegmentedAsync(null);
            int counter = 1;

            foreach (var container in containers.Results)
            {
                Console.WriteLine($"{counter++}) {container.Name}");
            }
        }
    }
}