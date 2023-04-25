using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Infra.Repositories;
using Mapster;

namespace FinancesAPI.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserReadContract> CreateAsync(UserCreateContract contract)
    {
        var user = await _userRepository.CreateAsync(contract.Adapt<User>());
        return user.Adapt<UserReadContract>();
    }

    public async Task Delete(int id)
    {
        var user = await _userRepository.GetAsync(id);
        if(user == null) return;
        await _userRepository.DeleteAsync(user);
    }

    public async Task<IEnumerable<UserReadContract>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Adapt<IEnumerable<UserReadContract>>();
    }

    public async Task<UserReadContract?> GetAsync(int id)
    {
        var user = await _userRepository.GetAsync(id);
        return user?.Adapt<UserReadContract>();
    }

    public async Task Update(UserUpdateContract contract)
    {
        var user = await _userRepository.GetAsync(contract.Id);
        if(user == null) return;
        contract.Adapt(user);
        await _userRepository.UpdateAsync(user);
    }
}