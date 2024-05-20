using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Domain.Entities
{
    public class Custumer : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
