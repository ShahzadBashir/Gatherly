using Gatherly.Domain.Entities;

namespace Gatherly.Application.Contracts.Persistence;

public interface IMemberRepository
{
    Task<Member> AddMemberAsync(Member member);
}
