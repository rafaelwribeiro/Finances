using FinancesAPI.Domain.Entities;

namespace FinancesAPI.Domain.Repositories;

public interface IUserRepository
{
    public Task<User> CreateAsync(User entity);
    public Task<IEnumerable<User>> GetAllAsync();
    public Task<User?> GetAsync(int id);
    public Task<User?> GetByUserName(string userName);
    public Task<bool> UserNameAlreadyInUse(string userName);
    public Task UpdateAsync(User entity);
    public Task DeleteAsync(User entity);
}