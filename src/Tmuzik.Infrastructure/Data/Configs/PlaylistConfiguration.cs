using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(Playlist)}", DbConst.TMusicSchema);

            builder.HasOne(b => b.Creator)
                .WithMany()
                .HasForeignKey(b => b.CreatorId);

            builder.HasMany(b => b.Items)
                .WithOne()
                .HasForeignKey(b => b.PlaylistId);
        }
    }
}