using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class FavouriteAudioConfiguration : IEntityTypeConfiguration<FavouriteAudio>
    {
        public void Configure(EntityTypeBuilder<FavouriteAudio> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(FavouriteAudio)}", DbConst.TMusicSchema);

            builder.HasOne(b => b.Audio)
                .WithMany()
                .HasForeignKey(b => b.AudioId);

            builder.HasOne(b => b.Creator)
                .WithMany()
                .HasForeignKey(b => b.CreatorId);
        }
    }
}