using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Configs
{
    public class SharedAlbumConfiguration : IEntityTypeConfiguration<SharedAlbum>
    {
        public void Configure(EntityTypeBuilder<SharedAlbum> builder)
        {
            builder.ToTable($"{DbConst.DbPrefix}{nameof(SharedAlbum)}", DbConst.TMusicSchema);

            builder.HasOne<Album>()
                .WithMany()
                .HasForeignKey(b => b.AlbumId);
            
            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(b => b.CreatorId);

            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(b => b.GrantedId);
        }
    }
}