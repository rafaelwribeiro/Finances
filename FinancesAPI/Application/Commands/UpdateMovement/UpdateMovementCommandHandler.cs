using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.UpdateMovement;

public class UpdateMovementCommandHandler : IRequestHandler<UpdateMovementCommand, UpdateMovementCommandResult>
{
    private readonly IMovementRepository _movementRepository;

    public UpdateMovementCommandHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<UpdateMovementCommandResult> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
    {
        var entity = await _movementRepository.GetAsync(request.Id);

        if(entity == null)
            throw new NotFoundException();

        request.Contract.Adapt(entity);

        await _movementRepository.UpdateAsync(entity);

        var result = new UpdateMovementCommandResult();

        return result;
    }
}