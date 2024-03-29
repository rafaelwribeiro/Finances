using FinancesAPI.Domain;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Infra;

public class SqlServerDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Movement> Movements { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }

    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoleMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new GroupMap());
        modelBuilder.ApplyConfiguration(new SubscriptionMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new MovementMap());
    }
}