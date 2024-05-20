using Finance.B4.Application.Handlers.Quotes.GetQuote;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.B4.Api.Controllers.V1.Quote.GetQuote
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuoteController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("GetQuoteBySymbol")]
        [ProducesResponseType(typeof(GetQuoteResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetQuoteBySymbol([FromBody] GetQuoteRequest input)
        {
            return Ok(await _mediator.Send(input));
        }
    }
}
