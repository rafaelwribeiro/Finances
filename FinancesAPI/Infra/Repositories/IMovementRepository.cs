using FinancesAPI.Domain;

namespace FinancesAPI.Infra.Repositories;
public interface IMovementRepository
{
    public Task<Movement> CreateAsync(Movement entity);
    public Task<IEnumerable<Movement>> GetAllAsync();
    public Task<Movement?> GetAsync(int id);
    public Task UpdateAsync(Movement entity);
    public Task DeleteAsync(Movement entity);
}