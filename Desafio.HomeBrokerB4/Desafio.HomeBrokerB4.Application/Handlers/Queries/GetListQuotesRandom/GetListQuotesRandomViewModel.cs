using Desafio.HomeBrokerB4.Domain.Entities;
using Desafio.HomeBrokerB4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Application.Handlers.Queries.GetListQuotesRandom
{
    public class GetListQuotesRandomViewModel
    {
        public List<QuoteInfoModel> QuoteInfoModels { get; set; }

        public GetListQuotesRandomViewModel(List<QuoteInfoModel> quoteInfoModels)
        {
            QuoteInfoModels = quoteInfoModels;
        }

        public GetListQuotesRandomViewModel()
        {
            QuoteInfoModels = new List<QuoteInfoModel>();
        }

        public static List<QuoteInfoModel> ToListQuoteInfoModels(List<Quote> quotes)
        {
            List<QuoteInfoModel> quoteInfoList = new List<QuoteInfoModel>();

            foreach (var item in quotes)
            {
                var quoteInfo = new QuoteInfoModel();
                quoteInfo.NameTitle = item.NameTitle;
                quoteInfo.Symbol = item.Symbol;
                quoteInfo.Value = item.Value;
                quoteInfo.DateLastConsult = item.DateLastConsult;
                quoteInfo.Amount = item.Amount;

                quoteInfoList.Add(quoteInfo);
            }

            return quoteInfoList;
        }
    }
}
