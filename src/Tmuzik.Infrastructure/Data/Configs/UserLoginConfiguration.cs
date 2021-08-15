using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(UserLogin)}", DbConst.IdentitySchema);
        }
    }
}