using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Menu.Blob
{
    static class TablesHelper
    {
        public static CloudBlobClient GetClient(string storageConnectionString)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            return storageAccount.CreateCloudBlobClient();
        }

        public static async Task<CloudBlobContainer> SelectContainer(CloudBlobClient blobClient)
        {
            ContainerResultSegment containers = await DisplayContainers(blobClient);

            Console.Write("Selected container: ");
            string itemNumberInput = Console.ReadLine();

            if (int.TryParse(itemNumberInput, out int itemNumber) && itemNumber > 0 && itemNumber < containers.Results.Count() + 1)
            {
                return containers.Results.ElementAt(itemNumber - 1);
            }
            else
            {
                return await SelectContainer(blobClient);
            }
        }

        public static async Task<ContainerResultSegment> DisplayContainers(CloudBlobClient blobClient)
        {
            Console.WriteLine();
            Console.WriteLine("Containers list:");

            ContainerResultSegment containers = await blobClient.ListContainersSegmentedAsync(null);
            int counter = 1;

            foreach (var container in containers.Results)
            {
                Console.WriteLine($"{counter++}) {container.Name}");
            }

            return containers;
        }

        public static async Task<IListBlobItem> SelectBlob(CloudBlobContainer blobContainer)
        {
            BlobResultSegment blobs = await DisplayBlobs(blobContainer);

            Console.Write("Selected blob: ");
            string itemNumberInput = Console.ReadLine();

            if (int.TryParse(itemNumberInput, out int itemNumber) && itemNumber > 0 && itemNumber < blobs.Results.Count() + 1)
            {
                return blobs.Results.ElementAt(itemNumber - 1);
            }
            else
            {
                return await SelectBlob(blobContainer);
            }
        }

        public static async Task<BlobResultSegment> DisplayBlobs(CloudBlobContainer blobContainer)
        {
            Console.WriteLine();
            Console.WriteLine("Blobs list:");

            BlobResultSegment blobs = await blobContainer.ListBlobsSegmentedAsync(null);
            int counter = 1;

            foreach (var blob in blobs.Results)
            {
                Console.WriteLine($"{counter++}) {Path.GetFileName(blob.Uri.AbsoluteUri)}");
            }

            return blobs;
        }

    }
}
