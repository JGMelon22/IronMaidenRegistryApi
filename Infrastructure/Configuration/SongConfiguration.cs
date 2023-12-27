using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IronMaidenRegistry.Infrastructure.Configuration;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.ToTable("Songs");

        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.Id)
            .HasDatabaseName("IDX_Id_Song");

        builder.Property(s => s.Id)
            .HasColumnName("SongId")
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .HasColumnType("VARCHAR")
            .HasColumnName("SongName")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(s => s.DurationInMinutes)
            .HasColumnType("TINYINT")
            .HasColumnName("DurationInMinutes")
            .IsRequired();

        builder.Property(s => s.AverageScore)
            .HasColumnType("TINYINT")
            .HasColumnName("AverageScore")
            .IsRequired();
    }
}