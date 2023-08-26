using FinancesAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancesAPI.Infra.Mapping;

public class MovementMap : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.ToTable("Movements");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder.Property(x => x.Date)
            .IsRequired()
            .HasColumnType("DATETIME")
            //.HasDefaultValue("GETDATE()");
            .HasDefaultValue(DateTime.Now.ToUniversalTime());
        
        builder.Property(x => x.Description)
            .HasColumnType("VARCHAR")
            .HasMaxLength(200);
        
        builder.Property(x => x.Value)
            .IsRequired()
            .HasColumnType("DECIMAL")
            .HasPrecision(10, 2);

        builder.HasOne(x => x.Category);
        builder.HasOne(x => x.Group);


        builder.HasOne(x => x.User);
    }
}