using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IronMaidenRegistry.Infrastructure.Configuration;

public class InstrumentConfiguration : IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        builder.ToTable("Instruments");

        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.Id)
            .HasDatabaseName("IDX_Id_Instrument");

        builder.Property(i => i.Id)
            .HasColumnName("InstrumentId")
            .ValueGeneratedOnAdd();

        builder.Property(i => i.Name)
            .HasColumnType("VARCHAR")
            .HasColumnName("InstrumentName")
            .HasMaxLength(8)
            .IsRequired();
    }
}