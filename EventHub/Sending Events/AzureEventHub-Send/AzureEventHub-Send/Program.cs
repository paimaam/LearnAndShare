using Azure.Messaging.EventHubs.Producer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureEventHub_Send
{
    class Program
    {
        private static string connection_string = "";
        static void Main(string[] args)
        {

            EventHubProducerClient _client = new EventHubProducerClient(connection_string);

            EventDataBatch _batch = _client.CreateBatchAsync().GetAwaiter().GetResult();

            List<Customer> _customers = new List<Customer>()
            {
               
                new Customer() {Id="O6",Name ="World" },
            };

            foreach (Customer _c in _customers)
                _batch.TryAdd(new Azure.Messaging.EventHubs.EventData(Encoding.UTF8.GetBytes(_c.ToString())));

            _client.SendAsync(_batch).GetAwaiter().GetResult();
            Console.WriteLine("Batch of events sent");
        }
    }
}
