using FinancesAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Infra.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly SqlServerDbContext _dbContext;

    public CategoryRepository(SqlServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> CreateAsync(Category entity)
    {
        await _dbContext.Categories.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Category entity)
    {
        _dbContext.Categories.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _dbContext.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Category> GetAsync(int id)
    {
        return await _dbContext.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Category entity)
    {
        _dbContext.Categories.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}