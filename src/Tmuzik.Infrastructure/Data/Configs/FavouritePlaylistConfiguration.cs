using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class FavouritePlaylistConfiguration : IEntityTypeConfiguration<FavouritePlaylist>
    {
        public void Configure(EntityTypeBuilder<FavouritePlaylist> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(FavouritePlaylist)}", DbConst.TMusicSchema);

            builder.HasOne(b => b.Playlist)
                .WithMany()
                .HasForeignKey(b => b.PlaylistId);

            builder.HasOne(b => b.Creator)
                .WithMany()
                .HasForeignKey(b => b.CreatorId);
        }
    }
}