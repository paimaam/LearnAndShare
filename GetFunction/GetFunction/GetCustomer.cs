using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GetFunction
{
        public static class GetCustomer
        {
            // This function is used to get the list of courses
            [FunctionName("GetAllCustomer")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
                ILogger log)
            {
                List<Customer> _lst = new List<Customer>();

                string _connection_string = "";
                string _statement = "select CustomerID, FirstName, LastName from dbo.customData2;";
                // We first establish a connection to the database
                SqlConnection _connection = new SqlConnection(_connection_string);
                _connection.Open();

                SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);
                // Using the SqlDataReader class , we can get all the rows from the table
                using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
                {
                    while (_reader.Read())
                    {
                        Customer _course = new Customer()
                        {
                            CustomerId = _reader.GetString(0),
                            FirstName = _reader.GetString(1),
                            LastName = _reader.GetString(2)
                        };

                        _lst.Add(_course);
                    }
                }
                _connection.Close();
                // Return the HTTP status code of 200 OK and the list of courses
                return new OkObjectResult(JsonConvert.SerializeObject(_lst));
            }
        }
}

