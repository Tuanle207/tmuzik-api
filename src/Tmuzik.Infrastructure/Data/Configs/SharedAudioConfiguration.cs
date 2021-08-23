using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class SharedAudioConfiguration : IEntityTypeConfiguration<SharedAudio>
    {
        public void Configure(EntityTypeBuilder<SharedAudio> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(SharedAudio)}", DbConst.TMusicSchema);

            builder.HasOne<Audio>()
                .WithMany()
                .HasForeignKey(b => b.AudioId);
            
            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(b => b.CreatorId);

            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(b => b.GrantedId);
        }
    }
}