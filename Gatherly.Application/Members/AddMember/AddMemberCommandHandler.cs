using Gatherly.Application.Contracts.Persistence;
using Gatherly.Application.Exceptions;
using MediatR;

namespace Gatherly.Application.Members.AddMember;

internal sealed class AddMemberCommandHandler : IRequestHandler<AddMemberCommand, AddMemberCommandResponse>
{
    private readonly IMemberRepository _memberRepository;

    public AddMemberCommandHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<AddMemberCommandResponse> Handle(AddMemberCommand request, CancellationToken cancellationToken)
    {
        var response = new AddMemberCommandResponse();

        var validator = new AddMemberCommandValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0) 
        {
            throw new ValidationException(validationResult);
        }

        throw new NotImplementedException();
    }
}
