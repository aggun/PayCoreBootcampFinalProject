using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PycApi.Dto.Dto;
using PycApi.RabbitMqServices;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PycApi.BackgroundServices
{
    public class SendEmailProcessBackgroundService : BackgroundService
    {
        private readonly RabbitMQClientService _rabbitMQClientService;
        private readonly ILogger<SendEmailProcessBackgroundService> _logger;
        private readonly SmtpConfigDto smtpConfigDto;
        private IModel _channel;
        public SendEmailProcessBackgroundService(IOptions<SmtpConfigDto> options, RabbitMQClientService rabbitMQClientService, ILogger<SendEmailProcessBackgroundService> logger)
        {
            smtpConfigDto = options.Value;
            _rabbitMQClientService = rabbitMQClientService;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMQClientService.Connect();

            _channel.BasicQos(0, 1, false);

            return base.StartAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);

            _channel.BasicConsume(RabbitMQClientService.QueueName, false, consumer);

            consumer.Received += Consumer_Received;


            return Task.CompletedTask;
        }

        private Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {


            Task.Delay(10000).Wait();


            try
            {
                var SendEmailEvent = JsonSerializer.Deserialize<SendEmailEvent>(Encoding.UTF8.GetString(@event.Body.ToArray()));


                using var client = CreateSmtpClient();


                MailMessageDto mailMessageDto = new MailMessageDto
                {
                    Body = "Kayıt işleminiz gerçekleşti Hoşgeldiniz",
                    To = SendEmailEvent.ToString(),
                    Subject = "Kullanıcı kayıt işlemi tamamlandı",
                    From = smtpConfigDto.User
                };
                MailMessage mailMessage = mailMessageDto.GetMailMessage();
                mailMessage.IsBodyHtml = true;
                client.SendMailAsync(mailMessage);

                _channel.BasicAck(@event.DeliveryTag, false);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;

        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        private SmtpClient CreateSmtpClient()
        {
            SmtpClient smtp = new SmtpClient(smtpConfigDto.Host, smtpConfigDto.Port);
            smtp.Credentials = new NetworkCredential(smtpConfigDto.User, smtpConfigDto.Password);
            smtp.EnableSsl = smtpConfigDto.UseSsl;
            return smtp;
        }

        public async Task SendMailAsync(MailMessageDto mailMessageDto)
        {
            MailMessage mailMessage = mailMessageDto.GetMailMessage();
            mailMessage.From = new MailAddress(smtpConfigDto.User);

            using var client = CreateSmtpClient();
            await client.SendMailAsync(mailMessage);
        }


    }
}
