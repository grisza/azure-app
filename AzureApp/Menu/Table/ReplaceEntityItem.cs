using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AzureApp.Menu.Table
{
    internal class ReplaceEntityItem : MenuItemBase
    {
        public ReplaceEntityItem(IMenu menu, IConfiguration configuration) : base(menu, configuration)
        {
        }

        protected override async Task Execute()
        {
            // TODO: Implement


            throw new NotImplementedException();
        }
    }
}