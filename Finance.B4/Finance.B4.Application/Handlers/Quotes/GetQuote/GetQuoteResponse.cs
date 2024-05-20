using Finance.B4.Domain.Dto.JsonBruto;
using Finance.B4.Domain.Entities;
using Finance.B4.Domain.Interfaces;

namespace Finance.B4.Application.Handlers.Quotes.GetQuote
{
    public class GetQuoteResponse : IOutput
    {
        public GetQuoteResponse(long custumerId, string nameTitle, string symbol, decimal value, DateTime dateLastConsult)
        {
            CustumerId = custumerId;
            NameTitle = nameTitle;
            Symbol = symbol;
            Value = value;
            DateLastConsult = dateLastConsult;
        }

        public GetQuoteResponse()
        {
            
        }

        public long CustumerId { get; set; }
        public string NameTitle { get; set; }
        public string Symbol { get; set; }
        public decimal Value { get; set; }
        public DateTime DateLastConsult { get; set; }

        public GetQuoteResponse QuoteToResponse(RootDto quote, GetQuoteRequest request)
        {
            return new GetQuoteResponse
            {
                NameTitle = request.Company,
                Symbol = request.Symbol,
                Value = quote.Chart.Result[0].Ativo.RegularMarketPrice,
                DateLastConsult = DateTime.Now,               
            };
        }
    }
}
