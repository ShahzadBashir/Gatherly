namespace Gatherly.Domain.Entities;

public class Member
{
    private Member(MemberId id, string firstName, string lastName, string emailAddress)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
    }

    public MemberId Id { get; private set; } = default!;
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string EmailAddress { get; private set; } = string.Empty;

    public static Member Create(
        MemberId id,
        string firstName,
        string lastName,
        string emailAddress
        )
    {
        return new Member(
            new MemberId(Guid.NewGuid()),
            firstName,
            lastName,
            emailAddress
            );
    }
}
