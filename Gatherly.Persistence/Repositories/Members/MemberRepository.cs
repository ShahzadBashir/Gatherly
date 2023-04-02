using Gatherly.Application.Contracts.Persistence;
using Gatherly.Domain.Entities;

namespace Gatherly.Persistence.Repositories.Members;

public class MemberRepository : IMemberRepository
{
    private readonly GatherlyDbContext _context;

    public MemberRepository(GatherlyDbContext context)
    {
        _context = context;
    }

    public async Task<Member> AddMemberAsync(Member member)
    {
        await _context.Members.AddAsync(member);
        await _context.SaveChangesAsync();
        return member;
    }
}
