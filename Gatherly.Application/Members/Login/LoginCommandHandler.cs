using Gatherly.Application.Contracts.Infrastructure.Jwt;
using Gatherly.Application.Contracts.Persistence;
using Gatherly.Application.Exceptions;
using Gatherly.Domain.Entities;
using MediatR;

namespace Gatherly.Application.Members.Login;

internal sealed class LoginCommandHandler
    : IRequestHandler<LoginCommand, string>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IMemberRepository memberRepository, IJwtProvider jwtProvider)
    {
        _memberRepository = memberRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Member? member = await _memberRepository.GetMemberByEmailAsync(request.EmailAddress);

        if (member is null)
        {
            throw new BadRequestException($"Member with this email '{request.EmailAddress}' not found");
        }

        string token = _jwtProvider.Generate(member);

        return token;
    }
}
