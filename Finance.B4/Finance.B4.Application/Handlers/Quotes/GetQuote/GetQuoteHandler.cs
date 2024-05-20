using Finance.B4.Application.Enums;
using Finance.B4.Application.Handlers.Abstration;
using Finance.B4.Domain.Dto.JsonBruto;
using Finance.B4.Domain.Interfaces;
using Finance.B4.Domain.Models;
using Finance.B4.Infra.Http;
using Newtonsoft.Json;

namespace Finance.B4.Application.Handlers.Quotes.GetQuote
{
    public class GetQuoteHandler : IEventHandler<GetQuoteRequest>
    {
        private readonly IYahooClient _yahooClient;

        public GetQuoteHandler(IYahooClient yahooClient)
        {
            //_quoteService = quoteService;
            _yahooClient = yahooClient;
        }

        public async Task<OutputModel> Handle(GetQuoteRequest request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();
            var quoteInfo = new RootDto();

            try
            {
                var response = await _yahooClient.GetQuoteB3Async(request.Symbol + ".SA");


                if (string.IsNullOrEmpty(response))
                {
                    return output.ResultErro($"{ErroCode.NotFout} - Quote não foi encontrado.").Response();
                }
                
                quoteInfo = JsonConvert.DeserializeObject<RootDto>(response);

                var quoteResponse = new GetQuoteResponse().QuoteToResponse(quoteInfo, request);

                return output.Result(quoteResponse).Response();
            }
            catch (Exception ex)
            {
                output.ResultErro($"{ErroCode.InternalError} - Erro ao tentar pegar informações do symbol '{request.Symbol}'. " +
                                  $" {ex.Message}");
                return output.Response();
            }
        }

    }
}

