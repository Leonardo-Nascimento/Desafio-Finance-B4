using Finance.B4.Application.Handlers.Abstration;

namespace Finance.B4.Application.Handlers.Quotes.GetQuote
{
    public class GetQuoteRequest : IRequestInput
    {
        public long CustumerId { get; set; }
        public string Symbol { get; set; }
        public string Company { get; set; }
        


    }
}
