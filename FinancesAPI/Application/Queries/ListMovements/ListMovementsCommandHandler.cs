using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.ListMovements;

public class ListMovementsCommandHandler : IRequestHandler<ListMovementsCommand, ListMovementsCommandResult>
{
    private readonly IMovementRepository _movementRepository;

    public ListMovementsCommandHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<ListMovementsCommandResult> Handle(ListMovementsCommand request, CancellationToken cancellationToken)
    {
        var entities = await _movementRepository.GetAllByGroupAsync(request.GroupId);

        var result = new ListMovementsCommandResult();
        result.Movements = entities.Adapt<IList<MovementReadContract>>();

        return result;
    }
}