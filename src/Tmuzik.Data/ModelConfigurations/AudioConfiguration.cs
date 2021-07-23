using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmuzik.Data.Models;

namespace Tmuzik.Data.ModelConfigurations
{
    // public class AudioConfiguration : IEntityTypeConfiguration<Audio>
    // {
    //     public void Configure(EntityTypeBuilder<Audio> builder)
    //     {
    //         builder.ToTable($"{DbConst.DbPrefix}{nameof(Audio)}", DbConst.TMusicSchema);

    //         builder.Property(b => b.AudioGenere)
    //             .HasColumnType("jsonb");

    //         builder.HasOne(b => b.Artist)
    //             .WithMany()
    //             .HasForeignKey(b => b.ArtistId);

    //         builder.HasOne(b => b.UploadedBy)
    //             .WithMany()
    //             .HasForeignKey(b => b.CreatorId);
    //     }
    // }
}