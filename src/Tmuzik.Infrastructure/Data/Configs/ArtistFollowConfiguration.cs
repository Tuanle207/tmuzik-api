using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class ArtistFollowConfiguration : IEntityTypeConfiguration<ArtistFollow>
    {
        public void Configure(EntityTypeBuilder<ArtistFollow> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(ArtistFollow)}", DbConst.TMusicSchema);

            builder.HasKey(b => new { b.ArtistId, b.FollowerId });

            builder.HasOne(b => b.Artist)
                .WithMany(at => at.Followers)
                .HasForeignKey(b => b.ArtistId);

            builder.HasOne(b => b.Follower)
                .WithMany(up => up.FollowingArtists)
                .HasForeignKey(b => b.FollowerId);
                
        }
    }
}