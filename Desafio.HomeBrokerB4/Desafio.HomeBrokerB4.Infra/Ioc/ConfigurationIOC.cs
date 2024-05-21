using Desafio.HomeBrokerB4.Domain.Interfaces.Repositories;
using Desafio.HomeBrokerB4.Infra.Repositoty;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Infra.Ioc
{
    public static class ConfigurationIOC
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            //Repository
            services.AddScoped<IQuoteRepository, QuoteRepository>();
        }


    }
}
