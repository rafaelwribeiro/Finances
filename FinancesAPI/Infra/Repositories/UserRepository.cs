using FinancesAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SqlServerDbContext _dbContext;

    public UserRepository(SqlServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> CreateAsync(User entity)
    {
        await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(User entity)
    {
        _dbContext.Users.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> GetAsync(int id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(User entity)
    {
        _dbContext.Users.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}