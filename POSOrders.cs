using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFYOC.Function.Data;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace BFYOC.Function
{
    public class POSOrders
    {
        [FunctionName("POSOrders")]
        public async Task Run([EventHubTrigger("bfyoceventhub-partition", 
            Connection = "bfyoceventhubregular_RootManageSharedAccessKey_EVENTHUB")] EventData[] events, 
        [CosmosDB(
        databaseName: "salesevents",
        collectionName: "orders",
        ConnectionStringSetting = "CosmosDbConnectionString")]IAsyncCollector<dynamic> documentsOut,
        
        ILogger log)
        {
            var exceptions = new List<Exception>();

            foreach (EventData eventData in events)
            {
                try
                {
                    string messageBody = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);
                    dynamic myevent = Newtonsoft.Json.JsonConvert.DeserializeObject(messageBody);
                    if (!string.IsNullOrEmpty(messageBody))
                    {
                        await documentsOut.AddAsync(new
                        {
                            id = System.Guid.NewGuid().ToString(),
                            locationId = "location",
                            order = myevent
                        });
                    }
                    // Replace these two lines with your processing logic.
                    log.LogInformation($"C# Event Hub trigger function processed a message: {messageBody}");
                    await Task.Yield();
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }

            // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.
            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }
    }
}
