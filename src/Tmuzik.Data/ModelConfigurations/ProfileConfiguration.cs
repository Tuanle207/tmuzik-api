using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Data.Models;

namespace Tmuzik.Data.ModelConfigurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(Profile)}", DbConst.IdentitySchema);
        }
    }
}