using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureApp.Menu.Blob
{
    internal class CopyBlobItem : MenuItemBase
    {
        public CopyBlobItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {            
            Console.Clear();
            Console.WriteLine("-----Copy Blob-----");

            CloudBlobClient blobClient = TablesHelper.GetClient(StorageConnectionString);

            // TODO: IMPLEMENT LISTING OF CONTAINERS TO PICK AND CONTAINER SELECTION
            CloudBlobContainer blobContainer = await TablesHelper.SelectContainer(blobClient);

            // TODO: IMPLEMENT LISTING OF BLOBS IN CONTAINER TO PICK AND BLOB SELECTION
            CloudBlockBlob blob = (CloudBlockBlob)await TablesHelper.SelectBlob(blobContainer);

            // TODO: GET THE NAME OF BLOB COPY
            Console.WriteLine();
            Console.WriteLine("Give blob's copy name:");
            string blobCopyName = Console.ReadLine();

            // TODO: COPY SELECTED BLOB TO NEW NAME

            CloudBlockBlob copyReference = blobContainer.GetBlockBlobReference(blobCopyName);
            string copyId = await copyReference.StartCopyAsync(blob);
            Console.WriteLine();
            Console.WriteLine($"Copy ID: {copyId}");

            Console.WriteLine($"Blob copy uri: {copyReference.Uri}");
            await TextCopy.Clipboard.SetTextAsync(copyReference.Uri.ToString());


        }
    }
}