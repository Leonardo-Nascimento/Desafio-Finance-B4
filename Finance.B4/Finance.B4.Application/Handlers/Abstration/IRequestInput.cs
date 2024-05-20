using Finance.B4.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.B4.Application.Handlers.Abstration
{
    public interface IRequestInput : IRequest<OutputModel>
    {
    }
}
