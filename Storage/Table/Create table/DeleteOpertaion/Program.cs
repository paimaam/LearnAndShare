using AzureTable;
using Microsoft.Azure.Cosmos.Table;
using System;

namespace DeleteOpertaion
{
    class Program
    {
        private static string connection_string = "";
        private static string table_name = "Customer";
        private static string partition_key = "Bangalore";
        private static string row_key = "C4";
        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient _table_client = _account.CreateCloudTableClient();

            CloudTable _table = _table_client.GetTableReference(table_name);

            TableOperation _operation = TableOperation.Retrieve<Customer>(partition_key, row_key);

            TableResult _result = _table.Execute(_operation);
            Customer _customer = _result.Result as Customer;

            TableOperation _delete_operation = TableOperation.Delete(_customer);

            TableResult _delete_result = _table.Execute(_delete_operation);

            Console.WriteLine("Customer information is deleted");

            Console.ReadKey();
        }
    }
}
