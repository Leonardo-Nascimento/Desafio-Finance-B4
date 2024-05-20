using Finance.B4.Domain.Event;

namespace Finance.B4.Domain.Interfaces.Services
{
    public interface IRabbitMQService
    {
        bool SendMessage(EventQuote message);
    }
}
