using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AzureApp.Menu.Blob
{
    internal class DisplayBlobMetadataItem : MenuItemBase
    {


        protected override async Task Execute()
        {
            Console.Clear();
            Console.WriteLine("-----Blob Metadata-----");

            // TODO: IMPLEMENT LISTING OF CONTAINERS TO PICK AND CONTAINER SELECTION
            // TODO: IMPLEMENT LISTING OF BLOBS IN CONTAINER TO PICK AND BLOB SELECTION
            // TODO: DISPLAY METADATA ENTRIES OF SELECTED BLOB

            throw new NotImplementedException();
        }

        public DisplayBlobMetadataItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }
    }
}