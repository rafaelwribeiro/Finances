using FinancesAPI.Domain;

namespace FinancesAPI.Infra.Repositories;

public interface IUserRepository
{
    public Task<User> CreateAsync(User entity);
    public Task<IEnumerable<User>> GetAllAsync();
    public Task<User?> GetAsync(int id);
    public Task UpdateAsync(User entity);
    public Task DeleteAsync(User entity);
}