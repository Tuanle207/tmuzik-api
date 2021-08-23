using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class ArtistSnapshotConfiguration : IEntityTypeConfiguration<ArtistSnapshot>
    {
        public void Configure(EntityTypeBuilder<ArtistSnapshot> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(ArtistSnapshot)}", DbConst.TMusicSchema);

            builder.HasOne(b => b.Artist)
                .WithMany()
                .HasForeignKey(b => b.ArtistId);
        }
    }
}