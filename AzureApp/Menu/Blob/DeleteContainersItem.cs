using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureApp.Menu.Blob
{
    internal class DeleteContainersItem : MenuItemBase
    {
        public DeleteContainersItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
            Console.Clear();
            Console.WriteLine("-----Delete Container-----");

            CloudBlobClient blobClient = TablesHelper.GetClient(StorageConnectionString);

            // TODO: IMPLEMENT LISTING OF CONTAINERS TO PICK AND CONTAINER SELECTION
            CloudBlobContainer blobContainer = await TablesHelper.SelectContainer(blobClient);

            // TODO: DELETE SELECTED CONTAINER
            await blobContainer.DeleteIfExistsAsync();
        }
    }
}