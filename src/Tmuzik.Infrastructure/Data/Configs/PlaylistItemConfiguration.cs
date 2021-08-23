using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class PlaylistItemConfiguration : IEntityTypeConfiguration<PlaylistItem>
    {
        public void Configure(EntityTypeBuilder<PlaylistItem> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(PlaylistItem)}", DbConst.TMusicSchema);

            builder.HasOne(b => b.Audio)
                .WithMany()
                .HasForeignKey(b => b.AudioId);
        }
    }
}