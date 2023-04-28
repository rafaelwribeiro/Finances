using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.GetMovement;

public class GetMovementCommandHandler : IRequestHandler<GetMovementCommand, GetMovementCommandResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetMovementCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetMovementCommandResult> Handle(GetMovementCommand request, CancellationToken cancellationToken)
    {
        var entity = await _categoryRepository.GetAsync(request.Id);

        if(entity == null)
            throw new NotFoundException();

        var result = new GetMovementCommandResult();
        result.Movement = entity.Adapt<MovementReadContract>();

        return result;
    }
}