using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureCosmosDB
{
    class Program
    {
        private static readonly string _connection_string = "";
        private static readonly string _database_name = "az204sample";
        private static readonly string _container_name = "customer";
        private static readonly string _partition_key = "/location";
        static void Main(string[] args)
        {
            //Connect to client
            // CosmosClient _cosmosclient=new CosmosClient(_connection_string);


            ////Create a Db
            //_cosmosclient.CreateDatabaseIfNotExistsAsync(_database_name).GetAwaiter().GetResult();

            ////_cosmosclient.CreateDatabaseAsync(_database_name).GetAwaiter().GetResult();
            //Console.WriteLine("Database created");

            ////Fetches DB name
            //Database _cosmos_db = _cosmosclient.GetDatabase(_database_name);

            ////Creates a container
            //_cosmos_db.CreateContainerAsync(_container_name, _partition_key).GetAwaiter().GetResult();
            //Console.WriteLine("Container created");
            //Console.ReadKey();


            #region Insert data
            //Customer _customer = new Customer()
            //{
            //    id = Guid.NewGuid(),
            //    location = "Bangalore1",
            //    name = "hello peeps"
            //};

            //Container _container = _cosmosclient.GetContainer(_database_name, _container_name);

            //_container.CreateItemAsync<Customer>(_customer).GetAwaiter().GetResult();

            //Console.WriteLine("Item is created");
            //Console.ReadKey();

            #endregion


            #region Bulk insert

            //CosmosClient _client = new CosmosClient(_connection_string, new CosmosClientOptions() { AllowBulkExecution = true });

            //List<Customer> customerBulkData = new List<Customer>()
            //{
            //new Customer() { id=Guid.NewGuid() , location = "bangalore", name ="cvf" },
            //new Customer() { id=Guid.NewGuid() , location = "bangalore", name ="abc" },
            //new Customer() { id=Guid.NewGuid() , location = "bangalore", name ="lmn" },
            //new Customer() { id=Guid.NewGuid() , location = "bangalore", name ="pqr" },
            //new Customer() { id=Guid.NewGuid() , location = "bangalore2", name ="xyz" },
            //new Customer() { id=Guid.NewGuid() , location = "bangalore90", name ="xyz" },
            //};

            //Container _container = _client.GetContainer(_database_name, _container_name);

            //List<Task> _tasks = new List<Task>();

            //foreach (Customer _cus in customerBulkData)
            //    _tasks.Add(_container.CreateItemAsync<Customer>(_cus, new PartitionKey(_cus.location)));

            //Task.WhenAll(_tasks).GetAwaiter().GetResult();

            //Console.WriteLine("Bulk insert completed");
            //Console.ReadKey();

            #endregion

            #region Get

            //CosmosClient _client = new CosmosClient(_connection_string);

            //string _query = "SELECT * FROM c";

            //QueryDefinition _definition = new QueryDefinition(_query);
            //Container _container = _client.GetContainer(_database_name, _container_name);

            //FeedIterator<Customer> _iterator = _container.GetItemQueryIterator<Customer>(_definition);

            //while (_iterator.HasMoreResults)
            //{
            //    FeedResponse<Customer> _response = _iterator.ReadNextAsync().GetAwaiter().GetResult();
            //    foreach (Customer _customer in _response)
            //    {
            //        Console.WriteLine($"Id is {_customer.id}");
            //        Console.WriteLine($"Custromer Location is {_customer.location}");
            //        Console.WriteLine($"Course name is {_customer.name}");
            //    }
            //}

            //Console.ReadKey();
            #endregion


            #region Update

            //CosmosClient _client = new CosmosClient(_connection_string);

            //Container _container = _client.GetContainer(_database_name, _container_name);

            //var _id = Guid.Parse("bc82092f-82e7-45f5-9a3d-138b7223faad");
            //string _partition_key = "Bangalore";

            //ItemResponse<Customer> _response = _container.ReadItemAsync<Customer>(_id.ToString(), new PartitionKey(_partition_key)).GetAwaiter().GetResult();

            //Customer _course = _response.Resource;

            //_course.name = "az peeps";
            //_course.location = "Bangalore";

            //_container.ReplaceItemAsync<Customer>(_course, _id.ToString(), new PartitionKey(_partition_key)).GetAwaiter().GetResult();

            //Console.WriteLine("Item has been updated");

            //Console.ReadKey();
            #endregion

            #region Delete

            CosmosClient _client = new CosmosClient(_connection_string);

            Container _container = _client.GetContainer(_database_name, _container_name);

            var _id = Guid.Parse("bc82092f-82e7-45f5-9a3d-138b7223faad");
            string _partition_key = "Bangalore";

            _container.DeleteItemAsync<Customer>(_id.ToString(), new PartitionKey(_partition_key)).GetAwaiter().GetResult();

            Console.WriteLine("Item has been deleted");

            Console.ReadKey();

            #endregion
        }
    }
}