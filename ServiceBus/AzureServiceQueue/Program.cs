using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;

namespace AzureServiceQueue
{
    class Program
    {
        private static string connection_string = "";
        private static string connection_string = "";
        private static string queue_name = "test";

        static void Main(string[] args)
        {

            List<Customer> _orders = new List<Customer>()
            {
                new Customer() {CustomerId="O1",Name="Dileep",Designation="Se"},
                 new Customer() {CustomerId="O2",Name="Raj",Designation="SSe"},
                  new Customer() {CustomerId="O3",Name="Simran",Designation="Se"},
                   new Customer() {CustomerId="O4",Name="Bala",Designation="Lead"},
                    new Customer() {CustomerId="O5",Name="Sharma",Designation="Intern"},

            };

            ServiceBusClient _client = new ServiceBusClient(connection_string);

            //ServiceBusSender _sender = _client.CreateSender(queue_name);

            //foreach (Customer _order in _orders)
            //{
            //    ServiceBusMessage _message = new ServiceBusMessage(_order.ToString());
            //    _message.ContentType = "application/json";
            //    _sender.SendMessageAsync(_message).GetAwaiter().GetResult();
            //}



            #region Peek

            // ServiceBusReceiver _receiver = _client.CreateReceiver(queue_name, new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.PeekLock });

            //// ServiceBusReceivedMessage _receivemessage = _receiver.ReceiveMessageAsync().GetAwaiter().GetResult();

            // var messagesinBatch = _receiver.ReceiveMessagesAsync(20).GetAwaiter().GetResult();

            // //Console.WriteLine(_receivemessage.Body);
            // //Console.WriteLine($"The Sequence number is {_receivemessage.SequenceNumber}");


            // Console.WriteLine("Batch Messages");
            // foreach (var item in messagesinBatch)
            // {
            //     Console.WriteLine(item.Body);
            //     Console.WriteLine($"The Sequence number is {item.SequenceNumber}");
            // }

            // Console.WriteLine("All of the messages have been sent");

            // //_receiver.CompleteMessageAsync(_receivemessage); // To make sure you delete the message

            // Console.ReadKey();
            #endregion

            #region ReceiveandDelete



            ServiceBusReceiver _receiverandDelete = _client.CreateReceiver(queue_name, new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });

            var _messages = _receiverandDelete.ReceiveMessagesAsync(5);

            foreach (var _message in _messages.Result)
            {
                Console.WriteLine($"The Sequence number is {_message.SequenceNumber}");
                Console.WriteLine(_message.Body);

            }

            #endregion
        }
    }
}
