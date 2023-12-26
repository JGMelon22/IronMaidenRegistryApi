using IronMaidenRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
            .IsRequired();

        builder.Property(m => m.BirthDate)
            .HasColumnType("DATE")
            .HasColumnName("BirthDate")
            .IsRequired();
    }
}