using System;
using System.Threading.Tasks;
using fncConsumidorParcial2.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace fncConsumidorParcial2
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync(
             [ServiceBusTrigger(
                    "colaparcial2",
                    Connection = "MyConn"
                    )]string myQueueItem,
                     [CosmosDB(
                            databaseName:"dbUbicuaParcial",
                            collectionName:"Temperaturas",
                            ConnectionStringSetting ="strCosmos"
                            )]IAsyncCollector<object> datos,
                     ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<ModelParcial>(myQueueItem);
                await datos.AddAsync(data);
            }
            catch (Exception ex)
            {
                log.LogError($"No fue posible insertar datos: {ex.Message}");
            }
        }

    }
}

