using apiProductorArrazola.Models;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace apiProductorArrazola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        //post
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] ModelParcial data)
        {
            string connectionString = "Endpoint=sb://queueparcial2ubicua.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=JfhgS7UOeVl9O8qBYv0WEqwP2YwxLAngjC+pWK5/1jA=;EntityPath=colaparcial2";
            string queueName = "colaparcial2";
            // JsonSerializer json = new JsonSerializer();
            string mensaje = JsonConvert.SerializeObject(data);
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }
            return true;
            }
        }
    }
