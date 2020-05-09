using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureApp.Menu.Blob
{
    internal class DeleteBlobItem : MenuItemBase
    {
        public DeleteBlobItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
          
            Console.Clear();
            Console.WriteLine("-----Delete Blob-----");

            // TODO: IMPLEMENT LISTING OF CONTAINERS TO PICK AND CONTAINER SELECTION
            // TODO: IMPLEMENT LISTING OF BLOBS IN CONTAINER TO PICK AND BLOB SELECTION
            // TODO: DELETE SELECTED BLOB

            throw new NotImplementedException();
        }
    }
}