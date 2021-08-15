using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(User)}", DbConst.IdentitySchema);

            builder.HasOne(b => b.Profile)
                .WithOne()
                .HasForeignKey<UserProfile>(e => e.UserId);

            builder.HasMany(b => b.UserLogins)
                .WithOne()
                .HasForeignKey(b => b.UserId);    
        }
    }
}