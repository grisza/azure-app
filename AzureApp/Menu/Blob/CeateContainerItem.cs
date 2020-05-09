using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureApp.Menu.Blob
{
    class CeateContainerItem : MenuItemBase
    {
        public CeateContainerItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            string containerName = "";
            Console.Clear();
            Console.WriteLine("-----Create Container-----");
            Console.WriteLine($"New container name:");
            containerName = Console.ReadLine().ToLower();

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            Console.WriteLine("Done!");
        }
    }
}