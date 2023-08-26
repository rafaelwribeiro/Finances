using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Infra.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly SqlServerDbContext _dbContext;

    public GroupRepository(SqlServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Group> CreateAsync(Group entity)
    {
        await _dbContext.Groups.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Group entity)
    {
        _dbContext.Groups.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Group>> GetAllAsync()
    {
        return await _dbContext.Groups.AsNoTracking().ToListAsync();
    }

    public async Task<Group?> GetAsync(int id)
    {
        return await _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Group entity)
    {
        _dbContext.Groups.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}