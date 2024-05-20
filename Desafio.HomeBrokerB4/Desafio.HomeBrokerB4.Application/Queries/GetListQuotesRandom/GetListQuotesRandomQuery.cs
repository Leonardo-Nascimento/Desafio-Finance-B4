using Desafio.HomeBrokerB4.Application.Utils;
using Desafio.HomeBrokerB4.Domain.Interfaces;
using Desafio.HomeBrokerB4.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Application.Queries.GetListQuotesRandom
{
    public class GetListQuotesRandomQuery : IRequest<Output>
    {
    }
}
