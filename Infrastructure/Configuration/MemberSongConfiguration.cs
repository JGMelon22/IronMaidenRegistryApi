using IronMaidenRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IronMaidenRegistry.Infrastructure.Configuration;

public class MemberSongConfiguration : IEntityTypeConfiguration<MemberSong>
{
    public void Configure(EntityTypeBuilder<MemberSong> builder)
    {
        builder.ToTable("MembersSongs");

        builder.HasKey(ms => new
        {
            ms.MemberId,
            ms.SongId
        });

        builder.HasIndex(ms => ms.MemberId)
            .HasDatabaseName("IDX_MemberId_MembersSongs");

        builder.HasIndex(ms => ms.SongId)
            .HasDatabaseName("IDX_SongId_MembersSongs");

        // Foreign Keys
        builder.HasOne(ms => ms.Member)
            .WithMany(m => m.MembersSongs)
            .HasForeignKey(ms => ms.MemberId);

        builder.HasOne(ms => ms.Song)
            .WithMany(s => s.MembersSongs)
            .HasForeignKey(ms => ms.SongId);
    }
}