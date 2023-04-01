using Gatherly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gatherly.Persistence;

public class GatherlyDbContext : DbContext
{
    public GatherlyDbContext(DbContextOptions<GatherlyDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GatherlyDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
