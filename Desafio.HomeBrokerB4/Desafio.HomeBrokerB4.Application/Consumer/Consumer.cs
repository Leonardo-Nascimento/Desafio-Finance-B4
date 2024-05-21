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
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Application.Consumer
{
    public class Consumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _chanel;
        private readonly IMediator _mediator;

        private readonly string _queue = "queue.quotes.random";


        public Consumer(IMediator mediator)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _chanel = _connection.CreateModel();

            _chanel.QueueDeclare(
                queue: _queue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            _mediator = mediator;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_chanel);
            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var ListQuotesRandom = JsonConvert.DeserializeObject<List<QuoteInfoModel>>(contentString);

                NotifyHandler(ListQuotesRandom);

                _chanel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _chanel.BasicConsume(_queue, false, consumer);

            return Task.CompletedTask;
        }

        public void NotifyHandler(List<QuoteInfoModel> quotesInfoModel)
        {
            var request = new GetListQuotesRandomQuery(quotesInfoModel);
            _mediator.Send(request);
        }
    }
}
