using MediatR;

namespace Gatherly.Application.Members.Login;

public record LoginCommand : IRequest<string>
{
    public string EmailAddress { get; set; } = string.Empty;
}
