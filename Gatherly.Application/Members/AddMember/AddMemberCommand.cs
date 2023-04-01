using MediatR;

namespace Gatherly.Application.Members.AddMember;

public class AddMemberCommand : IRequest<AddMemberCommandResponse>
{ 
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}
