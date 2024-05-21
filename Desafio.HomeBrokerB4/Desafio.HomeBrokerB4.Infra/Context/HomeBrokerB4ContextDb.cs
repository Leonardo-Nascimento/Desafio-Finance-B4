using Desafio.HomeBrokerB4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Infra.Context
{
    public class HomeBrokerB4ContextDb : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Quote> ShopQuote { get; set; }

        public HomeBrokerB4ContextDb(DbContextOptions<HomeBrokerB4ContextDb> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "HomeBrokerB4");
        }
    }
}
