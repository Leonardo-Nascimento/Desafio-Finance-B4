using Finance.B4.Application.Handlers.Quotes.GetListQuotesRandom;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.B4.Api.Controllers.V1.Quote.GetListQuotesRandom
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

        [HttpGet("GetQuotesRamdom")]
        [ProducesResponseType(typeof(GetListQuotesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetQuotesRamdom()
        {
            var input = new GetListQuotesRequest();            
            return Ok(await _mediator.Send(input));
        }
    }
}
