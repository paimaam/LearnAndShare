using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ChangeFeed1
{
    public static class Function1
    {
        [FunctionName("ReadChange")]
        public static void Run([CosmosDBTrigger(
            databaseName: "appdb",
            collectionName: "course",
            ConnectionStringSetting = "cosmosdbstring",
            LeaseCollectionName = "leases",CreateLeaseCollectionIfNotExists = true)]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                foreach (var _customer in input)
                {
                    log.LogInformation($"Customer id {_customer.Id}");
                    log.LogInformation($"Customer id {_customer.GetPropertyValue<Guid>("couseid")}");
                    log.LogInformation($"Customer name {_customer.GetPropertyValue<string>("location")}");
                    log.LogInformation($"Customer location {_customer.GetPropertyValue<string>("name")}");
                }
            }
        }
    }
}
