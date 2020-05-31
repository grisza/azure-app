using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureApp.Menu.Blob
{
    internal class ListBlobsItem : MenuItemBase
    {
        public ListBlobsItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
            Console.Clear();
            Console.WriteLine("-----Blobs listing-----");

            CloudBlobClient blobClient = TablesHelper.GetClient(StorageConnectionString);

            // TODO: IMPLEMENT LISTING OF CONTAINERS TO PICK AND CONTAINER SELECTION
            CloudBlobContainer blobContainer = await TablesHelper.SelectContainer(blobClient);

            // TODO: DISPLAY LIST OF BLOBS IN SELECTED CONTAINER
            await TablesHelper.DisplayBlobs(blobContainer);
        }
    }
}