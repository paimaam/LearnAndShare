﻿using Azure.Messaging.EventHubs.Consumer;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureEventHub_Receive
{
    class Program
    {
        private static string connection_string = "";
        private static string consumer_group="$Default";
        
        static async Task Main(string[] args)
        {
            EventHubConsumerClient _client = new EventHubConsumerClient(consumer_group, connection_string);

            // Lets only read from the first partition
            string PartitionID = (await _client.GetPartitionIdsAsync()).First();

            await foreach(PartitionEvent _event in _client.ReadEventsFromPartitionAsync(PartitionID,EventPosition.Earliest))
            {
                Console.WriteLine($"Partition ID {_event.Partition.PartitionId}");
                Console.WriteLine($"Data Offset {_event.Data.Offset}");
                Console.WriteLine($"Sequence Number {_event.Data.SequenceNumber}");
                Console.WriteLine($"Partition Key {_event.Data.PartitionKey}");
                Console.WriteLine(Encoding.UTF8.GetString(_event.Data.EventBody));
            }
            Console.ReadKey();
        }
    }
}
