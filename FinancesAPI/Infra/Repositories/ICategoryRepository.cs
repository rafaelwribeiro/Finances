using FinancesAPI.Domain;

namespace FinancesAPI.Infra.Repositories;

public interface ICategoryRepository
{
    public Task<Category> CreateAsync(Category entity);
    public Task<IEnumerable<Category>> GetAllAsync();
    public Task<Category?> GetAsync(int id);
    public Task UpdateAsync(Category entity);
    public Task DeleteAsync(Category entity);
}