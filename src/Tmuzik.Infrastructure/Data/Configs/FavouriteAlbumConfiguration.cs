using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class FavouriteAlbumConfiguration : IEntityTypeConfiguration<FavouriteAlbum>
    {
        public void Configure(EntityTypeBuilder<FavouriteAlbum> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(FavouriteAlbum)}", DbConst.TMusicSchema);

            builder.HasOne(b => b.Album)
                .WithMany()
                .HasForeignKey(b => b.AlbumId);

            builder.HasOne(b => b.Creator)
                .WithMany()
                .HasForeignKey(b => b.CreatorId);
        }
    }
}