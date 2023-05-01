using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.GetMovement;

public class GetMovementCommandHandler : IRequestHandler<GetMovementCommand, GetMovementCommandResult>
{
    private readonly IMovementRepository _movementRepository;

    public GetMovementCommandHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<GetMovementCommandResult> Handle(GetMovementCommand request, CancellationToken cancellationToken)
    {
        var entity = await _movementRepository.GetAsync(request.Id);

        if(entity == null)
            throw new NotFoundException();

        var result = new GetMovementCommandResult();
        result.Movement = entity.Adapt<MovementReadContract>();

        return result;
    }
}