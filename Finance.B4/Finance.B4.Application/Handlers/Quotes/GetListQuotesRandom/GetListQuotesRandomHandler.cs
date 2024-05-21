using Finance.B4.Application.Enums;
using Finance.B4.Application.Handlers.Abstration;
using Finance.B4.Domain.Event;
using Finance.B4.Domain.Interfaces.Services;
using Finance.B4.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using YahooQuotesApi;

namespace Finance.B4.Application.Handlers.Quotes.GetListQuotesRandom
{
    public class GetListQuotesRandomHandler : IEventHandler<GetListQuotesRequest>
    {
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;


        public GetListQuotesRandomHandler(IRabbitMQService rabbitMQService, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _rabbitMQService = rabbitMQService;
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public async Task<OutputModel> Handle(GetListQuotesRequest request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();
            var listQuotesSelected = new List<ActionModel>();
            var listQuotesInfo = new List<QuoteInfoModel>();
            var quotesModel = new QuotesModel();
            try
            {
                using (var reader = new StreamReader(@"empresa_na_bolsa.json"))
                {
                    var json = await reader.ReadToEndAsync();
                    quotesModel = JsonConvert.DeserializeObject<QuotesModel>(json);
                }

                var rand = new Random();

                for (int i = 0; i < 10; i++)
                {
                    var quote = quotesModel.Quotes[rand.Next(quotesModel.Quotes.Count())];
                    listQuotesSelected.Add(quote);
                }

                foreach (var quote in listQuotesSelected)
                {
                    var symbol = quote.Symbol + ".SA";
                    YahooQuotes yahooQuotes = new YahooQuotesBuilder().Build();
                    Security? security = await yahooQuotes.GetAsync(symbol);

                    if (security is null)
                        throw new ArgumentException("Unknown symbol: " + symbol);

                    var quoteInfo = new QuoteInfoModel()
                    {
                        NameTitle = quote.Company,
                        Symbol = quote.Symbol,
                        Value = security.RegularMarketPrice.Value,
                        DateLastConsult = DateTime.Now
                    };

                    listQuotesInfo.Add(quoteInfo);
                }
                var host = Environment.GetEnvironmentVariable("BASE_URL_RABBIT") ?? _configuration.GetSection("RabbitMQ:BaseUrl").Value;
                await Console.Out.WriteLineAsync("Vai publicar a mensagem na url:" + host);                
                

                var @event = new EventQuote(listQuotesInfo);
                _rabbitMQService.SendMessage(@event);
                await Console.Out.WriteLineAsync("publicoooouuu!!!!");

                return output.Response();

            }
            catch (Exception ex)
            {
                output.ResultErro($"{ErroCode.InternalError} - {ex.Message}");
                return output.Response();
            }
        }
    }
}

