using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureApp.Menu.Queue
{
    public class Message
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Sender { get; set; }
        public string Body { get; set; }
        public string MachineName { get; set; }

        public Message(string sender, string body)
        {
            Id = Guid.NewGuid();
            TimeStamp = DateTimeOffset.Now;
            MachineName = Environment.MachineName;
            Sender = sender;
            Body = body;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static Message FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Message>(json);
        }

        public override string ToString()
        {
            return $"ID: {Id}\nSent at: {TimeStamp}\nFrom: {Sender}@{MachineName}\n------BODY-----\n{Body}\n----------";
        }
    }
}
