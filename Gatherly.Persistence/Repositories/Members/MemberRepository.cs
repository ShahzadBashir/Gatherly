using Gatherly.Application.Contracts.Persistence;
using Gatherly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Member?> GetMemberByEmailAsync(string emailAddress)
    {
        return await _context.Members.SingleOrDefaultAsync(x => x.EmailAddress.ToLower() == emailAddress.ToLower());
    }
}
