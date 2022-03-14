using Azure.Messaging.EventGrid;
using System;
using Azure;
using System.Collections.Generic;
using System.Text.Json;

namespace EventGrid_PublishCustomTopic
{
    class Program
    {
        private static Uri topic_endpoint;
        private static AzureKeyCredential topic_accesskey;
        
        static void Main(string[] args)
        {
            topic_endpoint = new Uri("");
            topic_accesskey = new AzureKeyCredential("");

            EventGridPublisherClient _client = new EventGridPublisherClient(topic_endpoint, topic_accesskey);

            Customer _customer = new Customer()
            {
                CutsomerId = "O1",
                Name= "Dileep"
            };

            List<EventGridEvent> _eventsList = new List<EventGridEvent>()
            {
                new EventGridEvent("Creating new customer","app.creatcustomer","1.0",JsonSerializer.Serialize(_customer))
            };

            _client.SendEvents(_eventsList);
            Console.WriteLine("Sending Event");
            Console.ReadKey();
        }
    }
}
