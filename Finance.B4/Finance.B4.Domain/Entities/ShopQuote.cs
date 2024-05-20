using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.B4.Domain.Entities
{
    public class ShopQuote : BaseEntity
    {
        public long CustumerId { get; set; }
        public string NameTitle { get; set; }
        public string Symbol { get; set; }
        public decimal Value { get; set; }
        public DateTime DateLastConsult { get; set; }
        public long Amount { get; set; }
        public decimal TotalValue { get; set; }
    }
}
