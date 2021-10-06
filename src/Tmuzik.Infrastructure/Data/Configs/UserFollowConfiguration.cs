using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class UserFollowConfiguration : IEntityTypeConfiguration<UserFollow>
    {
        public void Configure(EntityTypeBuilder<UserFollow> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(UserFollow)}", DbConst.TMusicSchema);

            builder.HasKey(b => new { b.FolloweeId, b.FollowerId });

            builder.HasOne(b => b.Followee)
                .WithMany(up => up.Followers)
                .HasForeignKey(b => b.FolloweeId);

            builder.HasOne(b => b.Follower)
                .WithMany(up => up.Followings)
                .HasForeignKey(b => b.FollowerId);
        }
    }
}