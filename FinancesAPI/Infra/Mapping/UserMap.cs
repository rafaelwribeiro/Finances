using FinancesAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.EntityFrameworkCore.Metadata;

namespace FinancesAPI.Infra.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        /*builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);*/
        builder.Property(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

        builder.Property(x => x.Login)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
    }
}