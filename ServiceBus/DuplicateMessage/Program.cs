using Azure.Messaging.ServiceBus;
using AzureServiceQueue;
using System;

namespace DuplicateMessage
{
    class Program
    {

        private static string connection_string = "";
        private static string queue_name = "";
        static void Main(string[] args)
        {

            var customer = new Customer() { CustomerId = "O1", Name = "Dileep", Designation = "Se" };

            ServiceBusClient _client = new ServiceBusClient(connection_string);
            ServiceBusSender _sender = _client.CreateSender(queue_name);

            ServiceBusMessage _message = new ServiceBusMessage(customer.ToString());
            _message.MessageId = "1";

            _message.ApplicationProperties.Add("Department", "HR");
            _sender.SendMessageAsync(_message).GetAwaiter().GetResult();

            Console.WriteLine("Message sent");
            Console.ReadKey();
        }
    }
}
