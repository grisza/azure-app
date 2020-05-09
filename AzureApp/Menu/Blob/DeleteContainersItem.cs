using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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

            // TODO: IMPLEMENT LISTING OF CONTAINERS TO PICK AND CONTAINER SELECTION
            // TODO: DELETE SELECTED CONTAINER

            throw new NotImplementedException();
        }
    }
}