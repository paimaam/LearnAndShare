using AzureTable;
using Microsoft.Azure.Cosmos.Table;
using System;

namespace GetEntities
{
    class Program
    {
        private static string connection_string = "";
        private static string table_name = "Customer";
        private static string partition_key = "Bangalore";
        private static string row_key = "C2";

        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient _table_client = _account.CreateCloudTableClient();

            CloudTable _table = _table_client.GetTableReference(table_name);

            TableOperation _operation = TableOperation.Retrieve<Customer>(partition_key, row_key);

            TableResult _result = _table.Execute(_operation);

            Customer _customer = _result.Result as Customer;


            Console.WriteLine($"The customer name is {_customer.customername}");
            Console.WriteLine($"The customer city is {_customer.PartitionKey}");
            Console.WriteLine($"The customer id is {_customer.RowKey}");

            Console.ReadKey();
        }
    }
}