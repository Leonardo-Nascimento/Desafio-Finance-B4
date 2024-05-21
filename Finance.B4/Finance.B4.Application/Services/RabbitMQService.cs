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
        ConnectionFactory _factory;
        IConnection _conn;
        IModel _channel;

        public RabbitMQService(IConfiguration configuration)
        {

            _configuration = configuration;
            var host = Environment.GetEnvironmentVariable("BASE_URL_RABBIT") ?? _configuration.GetSection("RabbitMQ:BaseUrl").Value;

            _factory = new ConnectionFactory() { HostName = host == "localhost" ? host : "rabbitmq", Port = 5672 };
            
            _factory.UserName = "guest";
            _factory.Password = "guest";
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: "ListQuotesRandom",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }


        public bool SendMessage(EventQuote @event)
        {
            Console.WriteLine("var publicar no host:" + _factory.HostName);

            try
            {
                var message = ToMessage(@event);

                byte[] body = Encoding.UTF8.GetBytes(message);
                _channel.BasicPublish(exchange: "",
                                    routingKey: "ListQuotesRandom",
                                    basicProperties: null,
                                    body: body);

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
