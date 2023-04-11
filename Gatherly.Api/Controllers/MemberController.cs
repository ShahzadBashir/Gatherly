using Gatherly.Application.Members.AddMember;
using Gatherly.Application.Members.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gatherly.Api.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("name")]
        public ActionResult<string> Get()
        {
            return Ok("Shahzad");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AddMemberCommandResponse>> AddMember(AddMemberCommand command)
        {
            var member = await _mediator.Send(command);
            return Created("",member);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody]LoginCommand loginCommand)
        {
            string token = await _mediator.Send(loginCommand);
            return Ok(token);
        }
    }
}
