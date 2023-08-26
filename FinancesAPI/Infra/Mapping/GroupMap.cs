using FinancesAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancesAPI.Infra.Mapping;

public class GroupMap : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups");

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

        builder.HasOne(x => x.Owner);

        builder.HasMany(a => a.Subscriptions)
            .WithOne(b => b.Group)
            .HasForeignKey(b => b.GroupId);
    }
}