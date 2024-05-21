using Finance.B4.Domain.Event;
using Finance.B4.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections;
using System.Text;

namespace Finance.B4.Application.Services
{
    public class RabbitMQService : IRabbitMQService
    {

        private readonly IConfiguration _configuration;
        public RabbitMQService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public bool SendMessage(EventQuote @event)
        {
            var _factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("BASE_URL_RABBIT") ?? _configuration.GetSection("RabbitMQ:BaseUrl").Value
            };

            if (_factory.HostName != "localhost")
            {

                _factory.Endpoint.Port = 5672;
                _factory.Port = 5672;
            }



            try
            {
                var message = ToMessage(@event);

                using IConnection connection = _factory.CreateConnection();
                using IModel channel = connection.CreateModel();

                string queueName = "queue.quotes.random";
                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);                

                IBasicProperties properties = channel.CreateBasicProperties();

                Console.WriteLine($"Vai mandar a mensagem para a url: {_factory.HostName}");
                Console.WriteLine($"Na porta: {_factory.Endpoint.Port}");

                byte[] body = Encoding.UTF8.GetBytes(message);                
                channel.BasicPublish(exchange: string.Empty, routingKey: queueName, basicProperties: properties, body: body);
                
                Console.WriteLine($"Mandou a menssagem");


                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private string ToMessage(EventQuote @event)
        {
            return JsonConvert.SerializeObject(@event, Formatting.Indented);
        }



    }
}
