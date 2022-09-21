using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace PycApi.RabbitMqServices
{
    public class RabbitMQPublisher
    {
        private readonly RabbitMQClientService rabbitMQClientService;

        public RabbitMQPublisher(RabbitMQClientService rabbitMQClientService)
        {
            this.rabbitMQClientService = rabbitMQClientService;
        }

        public void Publish(SendEmailEvent sendEmailEvent)
        {
            var channel = rabbitMQClientService.Connect();

            var bodyString = JsonSerializer.Serialize(sendEmailEvent);

            var bodyByte = Encoding.UTF8.GetBytes(bodyString);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(exchange: RabbitMQClientService.ExchangeName, routingKey: RabbitMQClientService.RoutingWatermark, basicProperties: properties, body: bodyByte);

        }
    }
}
