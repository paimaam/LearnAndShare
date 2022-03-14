using StackExchange.Redis;
using System;
using System.Text.Json;

namespace RedisCacheObjects
{
    class Program
    {
        private static Lazy<ConnectionMultiplexer> cache_connection = CreateConnection();
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return cache_connection.Value;
            }
        }
        static void Main(string[] args)
        {
            IDatabase cache = Connection.GetDatabase();

            var idTobeUpdate = Guid.NewGuid().ToString();
            Console.WriteLine(idTobeUpdate);

            Customer _customer =
              new Customer { id = idTobeUpdate, name = "DJ" };

            cache.StringSet(_customer.id, JsonSerializer.Serialize<Customer>(_customer));

           // Getting the object back

            Customer get_customer = JsonSerializer.Deserialize<Customer>(cache.StringGet(_customer.id));

            Console.WriteLine($"The Customer Id  is {get_customer.id}");
            Console.WriteLine($"The name  is {get_customer.name}");

            Console.ReadKey();

        }

        private static Lazy<ConnectionMultiplexer> CreateConnection()
        {
            string cache_connectionstring = "";
            return new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(cache_connectionstring);
            });
        }
    }
}
