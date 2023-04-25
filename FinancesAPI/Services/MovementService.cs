using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain;
using FinancesAPI.Infra.Repositories;
using Mapster;

namespace FinancesAPI.Services;

public class MovementService : IMovementService
{
    private readonly IMovementRepository _movementRepository;

    public MovementService(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<MovementReadContract> CreateAsync(MovementCreateContract contract)
    {
        var movement = contract.Adapt<Movement>();
        var result = await _movementRepository.CreateAsync(movement);
        return result.Adapt<MovementReadContract>();
    }

    public async Task Delete(int id)
    {
        var movement = await _movementRepository.GetAsync(id);
        if(movement == null) return;
        await _movementRepository.DeleteAsync(movement);
    }

    public async Task<IEnumerable<MovementReadContract>> GetAllAsync()
    {
        var list = await _movementRepository.GetAllAsync();
        return list.Adapt<IEnumerable<MovementReadContract>>();
    }

    public async Task<MovementReadContract?> GetAsync(int id)
        => (await _movementRepository.GetAsync(id))?.Adapt<MovementReadContract>();
    

    public async Task Update(MovementUpdateContract contract)
    {
        var movement = await _movementRepository.GetAsync(contract.Id);
        if(movement == null) return;
        contract.Adapt(movement);
        await _movementRepository.UpdateAsync(movement);
    }
}