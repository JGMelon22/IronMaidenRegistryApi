using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IronMaidenRegistry.Infrastructure.Configuration;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members");

        builder.HasKey(m => m.Id);

        builder.HasIndex(m => m.Id)
            .HasDatabaseName("IDX_Id_Member");

        builder.Property(m => m.Id)
            .HasColumnName("MemberId")
            .ValueGeneratedOnAdd();

        builder.Property(m => m.FullName)
            .HasColumnType("VARCHAR")
            .HasColumnName("FullName")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(m => m.BirthDate)
            .HasColumnType("DATE")
            .HasColumnName("BirthDate")
            .IsRequired();

        // Foreign Keys
        builder.HasOne(m => m.Instrument)
            .WithMany(i => i.Members)
            .HasForeignKey(m => m.InstrumentId);
    }
}