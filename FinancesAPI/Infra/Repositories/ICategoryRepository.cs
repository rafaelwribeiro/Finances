using FinancesAPI.Domain;

namespace FinancesAPI.Infra.Repositories;

public interface ICategoryRepository
{
    public Task<Category> Create(Category entity);
    public Task<IEnumerable<Category>> GetAllAsync();
    public Task<Category> GetAsync(int id);
}