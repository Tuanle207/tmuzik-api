using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Data.Models;

namespace Tmuzik.Data.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(User)}", DbConst.IdentitySchema);

            builder.HasOne(b => b.Profile)
                .WithOne()
                .HasForeignKey<Profile>(e => e.UserId);
        }
    }
}