using Gatherly.Domain.Entities;

namespace Gatherly.Application.Members.AddMember;

public class MemberDto
{
    public MemberId Id { get; set; } = default!;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}
