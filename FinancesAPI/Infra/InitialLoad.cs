namespace FinancesAPI.Infra;

using System;
using FinancesAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class InitialLoad
{
    public static void Load(IServiceProvider serviceProvider)
    {
        using (var context = new SqlServerDbContext(serviceProvider.GetRequiredService<DbContextOptions<SqlServerDbContext>>()))
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            PopulateRoles(context);
        }
    }

    private static void PopulateRoles(SqlServerDbContext context)
    {
        if (!context.Roles.Any())
            CreateRoles(context);
        
        if (!context.Users.Any())
            CreateDefaultUser(context);
    }

    private static void CreateDefaultUser(SqlServerDbContext context)
    {
        var role = context.Roles.FirstOrDefault();
        if(role == null) return;

        var admin = new User();
        admin.Login = "admin";
        admin.Password = "admin";

        admin.RoleId = role.Id;
        admin.Role = role;

        context.Users.Add(admin);
        context.SaveChanges();
    }

    private static void CreateRoles(SqlServerDbContext context)
    {
        var role1 = new Role();
        role1.Id = 1;
        role1.Name = "Admin";

        var role2 = new Role();
        role2.Id = 2;
        role2.Name = "User";

        context.Roles.Add(role1);
        context.Roles.Add(role2);
        context.SaveChanges();
    }
}