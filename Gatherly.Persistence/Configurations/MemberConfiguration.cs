using Gatherly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gatherly.Persistence.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id).HasConversion(
            memberId => memberId.Value,
            value => new MemberId(value));

        builder.Property(m => m.FirstName).HasMaxLength(50);
        builder.Property(m => m.LastName).HasMaxLength(50);

        builder.HasIndex(m => m.EmailAddress).IsUnique();
        builder.Property(m => m.EmailAddress).HasMaxLength(256);
    }
}
