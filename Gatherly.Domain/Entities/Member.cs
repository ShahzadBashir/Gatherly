namespace Gatherly.Domain.Entities;

public class Member
{
    public MemberId Id { get; set; } = default!;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}
