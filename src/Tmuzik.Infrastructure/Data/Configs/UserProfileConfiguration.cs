using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class ProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(UserProfile)}", DbConst.TMusicSchema);
        }
    }
}