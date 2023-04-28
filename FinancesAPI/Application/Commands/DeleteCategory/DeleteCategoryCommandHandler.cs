using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<DeleteCategoryCommandResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _categoryRepository.GetAsync(request.Id);

        if(entity == null)
            throw new NotFoundException();

        await _categoryRepository.DeleteAsync(entity);

        var result = new DeleteCategoryCommandResult();

        return result;
    }
}