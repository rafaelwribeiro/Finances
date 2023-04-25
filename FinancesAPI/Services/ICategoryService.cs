using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Services;

public interface ICategoryService
{
    Task<CategoryReadContract> CreateAsync(CategoryCreateContract contract);
    Task<CategoryReadContract?> GetAsync(int id);
    Task<IEnumerable<CategoryReadContract>> GetAllAsync();
    Task Delete(int id);
    Task Update(CategoryUpdateContract contract);
}