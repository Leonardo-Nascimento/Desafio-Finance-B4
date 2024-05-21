using Desafio.HomeBrokerB4.Application.Dto;
using Desafio.HomeBrokerB4.Application.Handlers.Queries.GetListQuotesRandom;
using Desafio.HomeBrokerB4.Domain.Models;
using MediatR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Application.Consumer
{
    public class Consumer
    {


        private readonly string _queue = "queue.quotes.random";


        public Consumer()
        {
            
        }
        public async Task ExecuteAsync()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };
            factory.UserName = "guest";
            factory.Password = "guest";
            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();
            channel.QueueDeclare(queue: "ListQuotesRandom",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            
            var consumer = new EventingBasicConsumer(channel);
            GetListQuotesRandomQuery query;

            consumer.Received += (model, ea) =>
            {
                var contentArray = ea.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);

                //query = new GetListQuotesRandomQuery(response);
                //NotifyHandler(contentString);
                Response(contentString);
                //Console.WriteLine(" [x] Received from Rabbit: {0}", contentString);
            };
            channel.BasicConsume(queue: "ListQuotesRandom",
                                    autoAck: true,
                                    consumer: consumer);

            
        }

        public void NotifyHandler(string json)
        {
            var response = JsonConvert.DeserializeObject<QuoteInfoModelsDto>(json);
            var query = new GetListQuotesRandomQuery(response.ListQuotesInfo);
            //_mediator.Send(query);
        }

        public async void Response(string json)
        {
            var response = JsonConvert.DeserializeObject<QuoteInfoModelsDto>(json);
            foreach (var item in response.ListQuotesInfo)
            {
                Console.WriteLine(item);
            }
        }
    }
}
