using Desafio.HomeBrokerB4.Domain.Entities;
using Desafio.HomeBrokerB4.Domain.Interfaces;
using Desafio.HomeBrokerB4.Domain.Interfaces.Repositories;
using Desafio.HomeBrokerB4.Domain.Models;
using MediatR;

namespace Desafio.HomeBrokerB4.Application.Handlers.Queries.GetListQuotesRandom
{
    public class GetListQuotesRandomQueryHandler : IRequestHandler<GetListQuotesRandomQuery, IOutput>
    {
        private readonly IQuoteRepository _quoteRepository;

        public GetListQuotesRandomQueryHandler(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public async Task<IOutput> Handle(GetListQuotesRandomQuery request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();
            GetListQuotesRandomViewModel quotesResponse;



            var listQuotesRandom = await _quoteRepository.GetListQuotesRandom();

            if (listQuotesRandom == null || !listQuotesRandom.Any())
            {
                foreach (var item in request.QuoteInfoModels)
                {
                    var quote = new Quote();
                    quote.NameTitle = item.NameTitle;
                    quote.Symbol = item.Symbol;
                    quote.Value = item.Value;
                    quote.DateLastConsult = item.DateLastConsult;
                    quote.Amount = item.Amount;

                    await _quoteRepository.CreateQuote(quote);
                }

                quotesResponse = new GetListQuotesRandomViewModel(request.QuoteInfoModels);
                return output.Result(quotesResponse);
            }
            else
            {
                quotesResponse = new GetListQuotesRandomViewModel(request.QuoteInfoModels);
                return output.Result(quotesResponse);
            }
        }
    }
}
