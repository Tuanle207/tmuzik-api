using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class SharedPlaylistConfiguration : IEntityTypeConfiguration<SharedPlaylist>
    {
        public void Configure(EntityTypeBuilder<SharedPlaylist> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(SharedPlaylist)}", DbConst.TMusicSchema);

            builder.HasOne<Playlist>()
                .WithMany()
                .HasForeignKey(b => b.PlaylistId);
            
            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(b => b.CreatorId);

            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(b => b.GrantedId);
        }
    }
}