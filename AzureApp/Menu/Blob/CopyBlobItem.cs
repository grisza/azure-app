using System;
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

            // TODO: IMPLEMENT LISTING OF CONTAINERS TO PICK AND CONTAINER SELECTION
            // TODO: IMPLEMENT LISTING OF BLOBS IN CONTAINER TO PICK AND BLOB SELECTION
            // TODO: GET THE NAME OF BLOB COPY
            // TODO: COPY SELECTED BLOB TO NEW NAME

            throw new NotImplementedException();

        }
    }
}