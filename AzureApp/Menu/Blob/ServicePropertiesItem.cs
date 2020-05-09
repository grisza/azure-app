using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureApp.Menu.Blob
{
    class ServicePropertiesItem : MenuItemBase
    {
        public ServicePropertiesItem(IMenu parent, IConfiguration configuration) : base(parent, configuration)
        {
        }

        protected override async Task Execute()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            Console.Clear();
            Console.WriteLine("-----Blob Service Client Properties-----");
            Console.WriteLine($"Storage account name: {blobClient.Credentials.AccountName}");
            Console.WriteLine($"Authentication Scheme: {blobClient.AuthenticationScheme}");
            Console.WriteLine($"Base URI: {blobClient.BaseUri}");
            Console.WriteLine($"Primary URI: {blobClient.StorageUri.PrimaryUri}");
            Console.WriteLine($"Secondary URI: {blobClient.StorageUri.SecondaryUri}");
            Console.WriteLine($"Default buffer size: {blobClient.BufferManager?.GetDefaultBufferSize()}");
            Console.WriteLine($"Default delimiter: {blobClient.DefaultDelimiter}");
        }
    }
}