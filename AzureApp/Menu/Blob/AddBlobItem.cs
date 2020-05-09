using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureApp.Menu.Blob
{
    class AddBlobItem : MenuItemBase
    {
        public AddBlobItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            string blobPath = "";
            Console.Clear();
            Console.WriteLine("-----Add Blob-----");
            Console.WriteLine($"Blob path:");

            do
            {
                blobPath = Console.ReadLine().ToLower();

                if (System.IO.File.Exists(blobPath))
                {
                    Console.WriteLine();
                    Console.WriteLine("Select target container:");

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
                        CloudBlockBlob blob = selectedContainer.GetBlockBlobReference(Path.GetFileName(blobPath));
                        await blob.UploadFromFileAsync((blobPath));

                        Console.WriteLine($"Blob uri: {blob.Uri}");
                    }
                }
                else
                {
                    Console.WriteLine("File does not exist. Try again");
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                }
            } while (!System.IO.File.Exists(blobPath));
        }
    }
}
