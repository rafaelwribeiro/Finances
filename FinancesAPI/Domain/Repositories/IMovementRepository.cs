using FinancesAPI.Domain.Entities;

namespace FinancesAPI.Domain.Repositories;
public interface IMovementRepository
{
    public Task<Movement> CreateAsync(Movement entity);
    public Task<IEnumerable<Movement>> GetAllAsync();
    public Task<Movement?> GetAsync(int id);
    public Task<bool> IsThereWithCategoryAsync(int categoryId);
    public Task UpdateAsync(Movement entity);
    public Task DeleteAsync(Movement entity);
}