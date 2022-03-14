using Azure.Messaging.ServiceBus;
using AzureServiceQueue;
using System;
using System.Collections.Generic;

namespace Topics
{
    class Program
    {
        private static string connection_string = "";
        private static string topic_name = "";

        private static string subscription_name = "sub1";
        static void Main(string[] args)
        {
            List<Customer> _customers = new List<Customer>()
            {
                new Customer() {CustomerId="O1",Name="Dileep",Designation="Se"},
                 new Customer() {CustomerId="O2",Name="Raj",Designation="SSe"},
                  new Customer() {CustomerId="O3",Name="Simran",Designation="Se"},
                  // new Customer() {CustomerId="O4",Name="Bala",Designation="Lead"},
                  //  new Customer() {CustomerId="O5",Name="Sharma",Designation="Intern"},

            };

            ServiceBusClient _client = new ServiceBusClient(connection_string);
            ServiceBusSender _sender = _client.CreateSender(topic_name);

            int i = 1;
            foreach (Customer _customer in _customers)
            {
                ServiceBusMessage _message = new ServiceBusMessage(_customer.ToString());
                _message.MessageId = i.ToString();
                i++;
                _sender.SendMessageAsync(_message).GetAwaiter().GetResult();
            }

            Console.WriteLine("Messages sent");
            Console.ReadKey();


            #region ReceiveFromSubs

            // ServiceBusClient _client = new ServiceBusClient(connection_string);
            //ServiceBusReceiver _receiver = _client.CreateReceiver(topic_name, subscription_name, new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });

            //var _messages = _receiver.ReceiveMessagesAsync(3);

            //foreach (var _message in _messages.Result)
            //{
            //    Console.WriteLine($"The Sequence number is {_message.SequenceNumber}");
            //    Console.WriteLine(_message.Body);

            //}
            //Console.ReadKey();

            #endregion
        }
    }
}
