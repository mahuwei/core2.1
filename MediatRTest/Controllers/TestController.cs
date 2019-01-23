using System;
using System.Threading.Tasks;
using MediatR;
using MediatRTest.Commands.GetData;
using Microsoft.AspNetCore.Mvc;

namespace MediatRTest.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetData(string input) {
            try {
                var result = await _mediator.Send(new GetData(input));
                return Ok(result);
            }

            catch (Exception e) {
                return BadRequest(e.GetBaseException() == null ? e.Message : e.GetBaseException().Message);
            }
        }
    }
}