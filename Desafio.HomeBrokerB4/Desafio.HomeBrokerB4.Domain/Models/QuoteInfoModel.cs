using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Domain.Models
{
    public class QuoteInfoModel
    {
        public string NameTitle { get; set; }
        public string Symbol { get; set; }
        public decimal Value { get; set; }
        public DateTime DateLastConsult { get; set; }
        public long Amount { get; set; }
    }
}
