using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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

            // TODO: IMPLEMENT LISTING OF CONTAINERS TO PICK AND CONTAINER SELECTION
            // TODO: DISPLAY LIST OF BLOBS IN SELECTED CONTAINER

            throw new NotImplementedException();
        }
    }
}