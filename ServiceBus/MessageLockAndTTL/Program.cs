using Azure.Messaging.ServiceBus;
using AzureServiceQueue;
using System;
using System.Collections.Generic;

namespace MessageLockAndTTL
{
    class Program
    {
        private static string connection_string = "";
        private static string queue_name = "test";
        private static string dead_letter_queue_name = "test/$DeadLetterQueue";

        static void Main(string[] args)
        {

            List<Customer> _orders = new List<Customer>()
            {
                new Customer() {CustomerId=Guid.NewGuid().ToString(),Name="Dileep1",Designation="Se"},
                 new Customer() {CustomerId=Guid.NewGuid().ToString(),Name="Raj1",Designation="SSe"},

            };

            ServiceBusClient _client = new ServiceBusClient(connection_string);

             ServiceBusSender _sender = _client.CreateSender(queue_name);

            foreach (Customer _order in _orders)
            {
                ServiceBusMessage _message = new ServiceBusMessage(_order.ToString());
                _message.ContentType = "application/json";
                _message.TimeToLive = TimeSpan.FromSeconds(10);
                _sender.SendMessageAsync(_message).GetAwaiter().GetResult();
            }


            #region DLQ
            // ServiceBusClient _client = new ServiceBusClient(connection_string);

            //ServiceBusReceiver _receiver = _client.CreateReceiver(dead_letter_queue_name, new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.PeekLock });

            //ServiceBusReceivedMessage _message = _receiver.ReceiveMessageAsync().GetAwaiter().GetResult();

            //Console.WriteLine($"Dead Letter Reason {_message.DeadLetterReason}");
            //Console.WriteLine($"Dead Letter Description {_message.DeadLetterErrorDescription}");
            //Console.WriteLine(_message.Body);
            #endregion
        }
    }
}
