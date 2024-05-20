using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.B4.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreationDate { get; set; }
    }
}
