using Gatherly.Application.Members.AddMember;
using MediatR;
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

        [HttpPost]
        public async Task<IActionResult> AddMember(AddMemberCommand command)
        {
            var member = await _mediator.Send(command);
            return Ok(member);
        }
    }
}
