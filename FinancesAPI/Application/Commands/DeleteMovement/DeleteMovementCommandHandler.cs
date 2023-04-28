using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.DeleteMovement;

public class DeleteMovementCommandHandler : IRequestHandler<DeleteMovementCommand, DeleteMovementCommandResult>
{
    private readonly IMovementRepository _movementRepository;

    public DeleteMovementCommandHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<DeleteMovementCommandResult> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
    {
        var entity =  request.Adapt<Movement>();

        entity = await _movementRepository.GetAsync(request.Id);
        if(entity == null)
            throw new NotFoundException();

        await _movementRepository.DeleteAsync(entity);

        var result = new DeleteMovementCommandResult();

        return result;
    }
}