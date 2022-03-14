using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;

namespace AzureTable
{
    class Program
    {
        private static string connection_string = "";
        private static string table_name = "";
        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient _client = _account.CreateCloudTableClient();

            CloudTable _table = _client.GetTableReference(table_name);
            //_table.CreateIfNotExists();



            //Console.WriteLine("Table created");
            //Console.ReadKey();


            #region AddEntities

            //Customer _customer = new Customer("Dileep", "India", "C1");

            //TableOperation _operation = TableOperation.Insert(_customer);

            //TableResult _result = _table.Execute(_operation);

            //Console.WriteLine("Entity is added");

            //Console.ReadKey();
            #endregion


            #region Batch Entities
            //List<Customer> _customersInvalid = new List<Customer>()
            //{
            //new Customer("Dileep   1", "India", "C2"),
            //new Customer("Dileep 2", "Bnglr", "C3"),
            //new Customer("Dileep 3", "Mnglr", "C4"),
            //};


            List<Customer> _customers = new List<Customer>()
            {
            new Customer("Dileep   1", "Bangalore", "C2"),
            new Customer("Dileep 2", "Bangalore", "C3"),
            new Customer("Dileep 3", "Bangalore", "C4"),
            };

            TableBatchOperation _batchOperation = new TableBatchOperation();

            foreach (var customer in _customers)
                _batchOperation.Insert(customer);


            TableBatchResult _bResult = _table.ExecuteBatch(_batchOperation);

            Console.WriteLine("Entities are added");

            Console.ReadKey();
            #endregion
        }
    }
}
