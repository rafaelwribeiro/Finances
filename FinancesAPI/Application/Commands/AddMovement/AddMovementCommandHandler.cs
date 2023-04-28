using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.AddMovement;

public class AddMovementCommandHandler : IRequestHandler<AddMovementCommand, AddMovementCommandResult>
{
    private readonly IMovementRepository _movementRepository;

    public AddMovementCommandHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<AddMovementCommandResult> Handle(AddMovementCommand request, CancellationToken cancellationToken)
    {
        var entity =  request._contract.Adapt<Movement>();

        entity = await _movementRepository.CreateAsync(entity);

        var result = new AddMovementCommandResult();
        result.Movement = entity.Adapt<MovementReadContract>();

        return result;
    }
}