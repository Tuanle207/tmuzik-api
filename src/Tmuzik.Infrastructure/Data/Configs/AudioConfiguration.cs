using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class AudioConfiguration : IEntityTypeConfiguration<Audio>
    {
        public void Configure(EntityTypeBuilder<Audio> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(Audio)}", DbConst.TMusicSchema);

            builder.Property(b => b.Genre)
                .HasColumnType("jsonb");

            builder.HasOne(b => b.Artist)
                .WithMany()
                .HasForeignKey(b => b.ArtistId);

            builder.HasOne(b => b.UploadedBy)
                .WithMany()
                .HasForeignKey(b => b.CreatorId);
        }
    }
}