using Refit;

namespace Finance.B4.Infra.Http
{
    public interface IYahooClient
    {
        [Get("/{quote}")]
        Task<string> GetQuoteB3Async([AliasAs("quote")] string quote);
    }
}
