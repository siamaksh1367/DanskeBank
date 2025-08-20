using Project.Api.Core.Queries.WithdrawalQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WithdrawalController : ControllerBase
    {
        private readonly ILogger<WithdrawalController> _logger;
        private readonly IMediator _mediator;

        public WithdrawalController(ILogger<WithdrawalController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "GetWithdrawalDetail")]
        public async Task<ActionResult<IEnumerable<WithdrawalQueryResponse>>> Post([FromBody] WithdrawalQuery withdrawalQuery)
        {
            await Task.Delay(3000);
            var response = await _mediator.Send(withdrawalQuery);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }
    }
}
