using AzureTable;
using Microsoft.Azure.Cosmos.Table;
using System;

namespace UpdateEntity
{
    class Program
    {
        private static string connection_string = "";
        private static string table_name = "Customer";
        private static string partition_key = "Ind2";
        private static string row_key = "C8";

        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient _table_client = _account.CreateCloudTableClient();

            CloudTable _table = _table_client.GetTableReference(table_name);

            Customer _customer = new Customer("UserE", partition_key, row_key);


            TableOperation _operation = TableOperation.InsertOrMerge(_customer);

            TableResult _result = _table.Execute(_operation);

            Console.WriteLine("Customer information is updated");

            Console.ReadKey();
        }
    }
}
