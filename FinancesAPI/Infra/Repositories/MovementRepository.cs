using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Infra.Repositories;

public class MovementRepository : IMovementRepository
{
    private readonly SqlServerDbContext _dbContext;

    public MovementRepository(SqlServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Movement> CreateAsync(Movement entity)
    {
        await _dbContext.Movements.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Movement entity)
    {
        _dbContext.Movements.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Movement>> GetAllAsync()
        => await _dbContext
            .Movements
            .Include(x => x.Category)
            .Include(x => x.User)
            .AsNoTracking()
            .ToListAsync();


    public async Task<Movement?> GetAsync(int id)
        => await _dbContext
            .Movements
            .Include(x => x.Category)
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<bool> IsThereWithCategoryAsync(int categoryId)
    {
        return await _dbContext
            .Movements
            .AnyAsync(x => x.CategoryId == categoryId);
    }

    public async Task UpdateAsync(Movement entity)
    {
        _dbContext.Movements.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}