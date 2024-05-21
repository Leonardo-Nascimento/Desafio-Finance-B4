using Desafio.HomeBrokerB4.Domain.Entities;
using Desafio.HomeBrokerB4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Domain.Interfaces.Repositories
{
    public interface IQuoteRepository
    {
        Task<List<Quote>> GetListQuotesRandom();
        Task CreateQuote(Quote quote);
    }
}
