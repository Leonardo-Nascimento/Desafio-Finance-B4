// See https://aka.ms/new-console-template for more information


using System.Text;
using Desafio.HomeBrokerB4.Application.Dto;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
factory.UserName = "guest";
factory.Password = "guest";

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "ListQuotesRandom",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);


consumer.Received += (model, ea) =>
{
    var contentArray = ea.Body.ToArray();
    var contentString = Encoding.UTF8.GetString(contentArray);

    var response = JsonConvert.DeserializeObject<QuoteInfoModelsDto>(contentString);
    foreach (var item in response.ListQuotesInfo)
    {
        Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
    }
};
channel.BasicConsume(queue: "ListQuotesRandom",
                        autoAck: true,
                        consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();



