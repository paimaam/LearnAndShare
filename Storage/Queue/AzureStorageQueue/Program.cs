using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;

namespace AzureStorageQueue
{
    class Program
    {

        private static string storage_connection_string = "";
        private static string queue_name = "";
        static void Main(string[] args)
        {
            QueueClient _client = new QueueClient(storage_connection_string,queue_name);

            //string _message;
            //if (_client.Exists())
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        _message = $"Hello from me  {i} times";
            //        _client.SendMessage(_message);
            //    }
            //}

            // Console.WriteLine("All the messages have been sent");



            #region PeekMessage


            //if (_client.Exists())
            //{
            //    PeekedMessage[] _messages = _client.PeekMessages(10); // class peek message
            //    foreach (PeekedMessage _messagee in _messages)
            //    {
            //        Console.WriteLine($"Message ID is {_messagee.MessageId}");
            //        Console.WriteLine($"Message was inserted on {_messagee.InsertedOn}");
            //        Console.WriteLine($"Message body is {_messagee.Body.ToString()}");
            //    }
            //}
            #endregion

            //Console.ReadKey();


            #region Receive message
            QueueMessage _queue_message = _client.ReceiveMessage();

            Console.WriteLine(_queue_message.Body.ToString());

            //_client.DeleteMessage(_queue_message.MessageId, _queue_message.PopReceipt); // pop receipt just like acknolwdge

            Console.WriteLine("Message deleted");
            #endregion
        }
    }
}
