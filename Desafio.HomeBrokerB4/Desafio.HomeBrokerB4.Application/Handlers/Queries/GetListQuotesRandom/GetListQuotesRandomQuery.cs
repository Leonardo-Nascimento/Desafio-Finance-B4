using Desafio.HomeBrokerB4.Domain.Interfaces;
using Desafio.HomeBrokerB4.Domain.Models;
using MediatR;

namespace Desafio.HomeBrokerB4.Application.Handlers.Queries.GetListQuotesRandom
{
    public class GetListQuotesRandomQuery : IRequest<IOutput>
    {
        public List<QuoteInfoModel> QuoteInfoModels { get; set; }

        public GetListQuotesRandomQuery(List<QuoteInfoModel> quoteInfoModels)
        {
            QuoteInfoModels = quoteInfoModels;
        }

        public GetListQuotesRandomQuery()
        {
            
        }
    }
}
