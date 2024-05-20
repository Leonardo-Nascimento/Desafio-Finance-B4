using Finance.B4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.B4.Domain.Event
{
    public record EventQuote(List<QuoteInfoModel> listQuotesInfo);


}
