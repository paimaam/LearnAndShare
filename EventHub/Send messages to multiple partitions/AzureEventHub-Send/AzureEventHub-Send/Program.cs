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
            List<Customer> _cutsomers = new List<Customer>();

            for (int i = 0; i < 20; i++)

            {
                _cutsomers.Add(new Customer() { Id = "O1", Name = $"Dileep{i}" });


                foreach (Customer _customer in _cutsomers)
                    _batch.TryAdd(new Azure.Messaging.EventHubs.EventData(Encoding.UTF8.GetBytes(_cutsomers.ToString())));

                _client.SendAsync(_batch).GetAwaiter().GetResult();
                Console.WriteLine("Batch of events sent");
            }
        }
    }
}
