using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureApp.Menu.Queue
{
    public sealed class QueueContext
    {
        public CloudQueue SelectedCloudQueue = null;

        private static QueueContext instance;
        private static readonly object padlock = new object();

        public static QueueContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if(instance == null)
                        {
                            instance = new QueueContext();
                        }
                    }
                }

                return instance;
            }
        }

        private QueueContext()
        {

        }
    }
}
