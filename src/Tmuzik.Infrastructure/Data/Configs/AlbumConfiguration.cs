using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class AlbumConfiguration: IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(Album)}", DbConst.TMusicSchema);

            builder.HasOne(b => b.Creator)
                .WithMany()
                .HasForeignKey(b => b.CreatorId);

            builder.HasOne(b => b.Artist)
                .WithMany()
                .HasForeignKey(b => b.ArtistId);

            builder.HasMany(b => b.Items)
                .WithOne()
                .HasForeignKey(b => b.AlbumId);
                
        }
    }
}