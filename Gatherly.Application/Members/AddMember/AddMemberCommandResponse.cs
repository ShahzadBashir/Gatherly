using Gatherly.Application.Responses;
using Gatherly.Domain.Entities;

namespace Gatherly.Application.Members.AddMember;

public class AddMemberCommandResponse : BaseReponse
{
    public MemberDto Member { get; set; } = default!;
}