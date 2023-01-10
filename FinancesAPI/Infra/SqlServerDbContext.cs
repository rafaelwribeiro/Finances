using FinancesAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Infra;

public class SqlServerDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Movement> Movements { get; set; }

    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
    {

    }
}