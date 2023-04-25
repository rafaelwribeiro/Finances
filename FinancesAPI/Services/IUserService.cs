using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Services;
public interface IUserService
{
    Task<UserReadContract> CreateAsync(UserCreateContract contract);
    Task<UserReadContract?> GetAsync(int id);
    Task<IEnumerable<UserReadContract>> GetAllAsync();
    Task Delete(int id);
    Task Update(UserUpdateContract contract);
}