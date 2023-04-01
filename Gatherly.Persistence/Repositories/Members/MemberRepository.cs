using Gatherly.Application.Contracts.Persistence;
using Gatherly.Domain.Entities;

namespace Gatherly.Persistence.Repositories.Members;

public class MemberRepository : IMemberRepository
{
    public Task<Member> AddMemberAsync(Member member)
    {
        throw new NotImplementedException();
    }
}
