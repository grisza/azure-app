using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureApp.Menu.Blob
{
    internal class DisplayBlobMetadataItem : MenuItemBase
    {


        protected override async Task Execute()
        {
            Console.Clear();
            Console.WriteLine("-----Blob Metadata-----");

            CloudBlobClient blobClient = TablesHelper.GetClient(StorageConnectionString);

            // TODO: IMPLEMENT LISTING OF CONTAINERS TO PICK AND CONTAINER SELECTION
            CloudBlobContainer blobContainer = await TablesHelper.SelectContainer(blobClient);

            // TODO: IMPLEMENT LISTING OF BLOBS IN CONTAINER TO PICK AND BLOB SELECTION
            CloudBlockBlob blob = (CloudBlockBlob)await TablesHelper.SelectBlob(blobContainer);

            // TODO: DISPLAY METADATA ENTRIES OF SELECTED BLOB

            Console.WriteLine();
            Console.WriteLine("Selected blob metadata:");

            foreach (var metadata in blob.Metadata)
            {
                Console.WriteLine($"{metadata.Key} - {metadata.Value}");
            }
        }

        public DisplayBlobMetadataItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }
    }
}