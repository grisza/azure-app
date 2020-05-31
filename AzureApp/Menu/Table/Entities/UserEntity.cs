using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureApp.Menu.Table.Entities
{
    public class UserEntity : TableEntity
    {
        public UserEntity()
        {

        }

        public UserEntity(string lastName, string firstName, int age)
        {
            this.PartitionKey = lastName;
            this.RowKey = firstName;
            Age = age;
            CreationTime = DateTime.Now;
        }

        public string Name
        {
            get
            {
                return $"{this.PartitionKey} {this.RowKey}";
            }
        }
        public int Age { get; set; }
        public DateTime CreationTime { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\tAge: {Age}\tCreation Time: {CreationTime}\tETag: {ETag}";
        }
    }
}
