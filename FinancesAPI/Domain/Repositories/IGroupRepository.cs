using FinancesAPI.Domain.Entities;

namespace FinancesAPI.Domain.Repositories;

public interface IGroupRepository
{
    public Task<Group> CreateAsync(Group entity);
    public Task<IEnumerable<Group>> GetAllAsync();
    public Task<Group?> GetAsync(int id);
    public Task UpdateAsync(Group entity);
    public Task DeleteAsync(Group entity);
}