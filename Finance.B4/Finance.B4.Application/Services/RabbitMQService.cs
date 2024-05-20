using Finance.B4.Domain.Event;
using Finance.B4.Domain.Interfaces.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections;
using System.Text;

namespace Finance.B4.Application.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly ConnectionFactory _factory;
        public RabbitMQService()
        {

            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                //Port = 15672,
                //Ssl = {
                //    ServerName = "localhost",
                //    Enabled = true,
                //}
            };

        }
        public bool SendMessage(EventQuote @event)
        {
            try
            {
                var message = ToMessage(@event);

                using IConnection connection = _factory.CreateConnection();
                using IModel channel = connection.CreateModel();

                string queueName = "queue.quotes.random";
                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                
                

                IBasicProperties properties = channel.CreateBasicProperties();
                //properties.Persistent = true;


                byte[] body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: string.Empty, routingKey: queueName, basicProperties: properties, body: body);

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
