using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class AlbumSnapshotConfiguration : IEntityTypeConfiguration<AlbumSnapshot>
    {
        public void Configure(EntityTypeBuilder<AlbumSnapshot> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(AlbumSnapshot)}", DbConst.TMusicSchema);

            builder.HasOne(b => b.Album)
                .WithMany()
                .HasForeignKey(b => b.AlbumId);
        }
    }
}