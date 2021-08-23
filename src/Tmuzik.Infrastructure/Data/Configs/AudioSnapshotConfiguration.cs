using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class AudioSnapshotConfiguration : IEntityTypeConfiguration<AudioSnapshot>
    {
        public void Configure(EntityTypeBuilder<AudioSnapshot> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(AudioSnapshot)}", DbConst.TMusicSchema);

            builder.HasOne(b => b.Audio)
                .WithMany()
                .HasForeignKey(b => b.AudioId);
        }
    }
}