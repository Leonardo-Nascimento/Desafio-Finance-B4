using Finance.B4.Domain.Interfaces;
using Finance.B4.Domain.Models;

namespace Finance.B4.Application.Handlers.Quotes.GetListQuotesRandom
{
    public class GetListQuotesResponse : IOutput
    {
        public List<QuoteInfoModel> Quotes { get; set; }



        public GetListQuotesResponse(List<QuoteInfoModel> quotes)
        {
            Quotes = quotes;
        }
    }
}
