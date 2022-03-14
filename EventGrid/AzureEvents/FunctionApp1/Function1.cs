// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("BlobEvents")]
        public static void Run([EventGridTrigger]EventGridEvent eventGridEvent, ILogger log)
        {
        //    log.LogInformation(eventGridEvent.Data.ToString());

            #region Event Schema
            log.LogInformation($"The topic is {eventGridEvent.Topic}");
            log.LogInformation($"The event type is {eventGridEvent.EventType}");
            log.LogInformation($"The event id is {eventGridEvent.Id}");
            log.LogInformation($"The event subject is {eventGridEvent.Subject}");
            #endregion
        }
    }
}
