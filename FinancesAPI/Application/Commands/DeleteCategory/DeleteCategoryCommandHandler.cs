using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResult>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMovementRepository _movementRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMovementRepository movementRepository)
    {
        _categoryRepository = categoryRepository;
        _movementRepository = movementRepository;
    }

    public async Task<DeleteCategoryCommandResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _categoryRepository.GetAsync(request.Id);

        if(entity == null)
            throw new NotFoundException();

        var movementWithThisCategory = await _movementRepository.GetByCategoryAsync(entity.Id);
        if(movementWithThisCategory != null)
            throw new BusinessLogicException("There is one or more Movements using this category");

        await _categoryRepository.DeleteAsync(entity);

        var result = new DeleteCategoryCommandResult();

        return result;
    }
}