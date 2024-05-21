using Desafio.HomeBrokerB4.Domain.Entities;
using Desafio.HomeBrokerB4.Domain.Interfaces.Repositories;
using Desafio.HomeBrokerB4.Domain.Models;
using Desafio.HomeBrokerB4.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Infra.Repositoty
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly HomeBrokerB4ContextDb _context;

        public QuoteRepository(HomeBrokerB4ContextDb context)
        {
            _context = context;
        }

        public async Task CreateQuote(Quote quote)
        {
            await _context.AddAsync(quote);
            _context.SaveChanges();
        }

        public async Task<List<Quote>> GetListQuotesRandom()
        {
            return await _context.Quotes.ToListAsync();
        }


    }
}
