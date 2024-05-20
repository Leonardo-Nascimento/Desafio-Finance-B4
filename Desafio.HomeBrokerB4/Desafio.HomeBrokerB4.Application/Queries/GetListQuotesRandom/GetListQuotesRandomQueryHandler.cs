using Desafio.HomeBrokerB4.Application.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Application.Queries.GetListQuotesRandom
{
    public class GetListQuotesRandomQueryHandler : IRequestHandler<GetListQuotesRandomQuery, Output>
    {
        public async Task<Output> Handle(GetListQuotesRandomQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}
