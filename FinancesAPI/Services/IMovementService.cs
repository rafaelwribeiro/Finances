using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Services;
public interface IMovementService
{
    Task<MovementReadContract> CreateAsync(MovementCreateContract contract);
    Task<MovementReadContract?> GetAsync(int id);
    Task<IEnumerable<MovementReadContract>> GetAllAsync();
    Task Delete(int id);
    Task Update(MovementUpdateContract contract);
}