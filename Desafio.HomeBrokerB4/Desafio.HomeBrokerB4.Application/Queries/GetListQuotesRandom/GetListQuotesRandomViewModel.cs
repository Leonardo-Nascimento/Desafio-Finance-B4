using Desafio.HomeBrokerB4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Application.Queries.GetListQuotesRandom
{
    public class GetListQuotesRandomViewModel
    {
        public List<QuoteInfoModel> Quotes { get; set; }



        public GetListQuotesRandomViewModel(List<QuoteInfoModel> quotes)
        {
            Quotes = quotes;
        }
    }
}
