using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    internal class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(Artist)}", DbConst.TMusicSchema);
            
            builder.Property(b => b.Photo)
                .HasColumnType("jsonb");

            builder.HasOne(b => b.BelongsTo)
                .WithMany()
                .HasForeignKey(b => b.CreatorId);
        }
    }
}