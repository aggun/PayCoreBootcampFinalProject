using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;

namespace PycApi.RabbitMqServices
{
    public class RabbitMQClientService : IDisposable
    {
        private readonly ConnectionFactory connectionFactory;
        private IConnection connection;
        private IModel channel;
        public static string ExchangeName = "EmailDirectExchange";
        public static string RoutingWatermark = "watermark-route-email";
        public static string QueueName = "queue-watermark-email";

        private readonly ILogger<RabbitMQClientService> logger;

        public RabbitMQClientService(ConnectionFactory connectionFactory, ILogger<RabbitMQClientService> logger)
        {
            this.connectionFactory = connectionFactory;
           this.logger = logger;
        }

        public IModel Connect()
        {
            connection = connectionFactory.CreateConnection();

            if (channel is { IsOpen: true })
            {
                return channel;
            }

            channel = connection.CreateModel();

            channel.ExchangeDeclare(ExchangeName, type: "direct", true, false);

            channel.QueueDeclare(QueueName, true, false, false, null);

            channel.QueueBind(exchange: ExchangeName, queue: QueueName, routingKey: RoutingWatermark);

            logger.LogInformation("RabbitMQ ile bağlantı kuruldu...");

            return channel;

        }

        public void Dispose()
        {
            channel?.Close();
            channel?.Dispose();
            connection?.Close();
            connection?.Dispose();
            logger.LogInformation("RabbitMQ ile bağlantı koptu...");
        }
    }
}
