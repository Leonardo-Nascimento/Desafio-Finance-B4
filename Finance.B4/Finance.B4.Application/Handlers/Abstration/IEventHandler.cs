using Finance.B4.Domain.Models;
using MediatR;

namespace Finance.B4.Application.Handlers.Abstration
{
    public interface IEventHandler<TInput> : IRequestHandler<TInput, OutputModel> where TInput : IRequestInput
    {
    }
}
