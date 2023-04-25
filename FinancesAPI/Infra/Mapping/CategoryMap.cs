using FinancesAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancesAPI.Infra.Mapping;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        // Primary Key
        builder.HasKey(x => x.Id);
        
        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(); //PRIMARY KEY IDENTITY(1, 1)

        // Properties
        builder.Property(x => x.Name)
            .IsRequired() // NOT NULL
            //.HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
    }
}