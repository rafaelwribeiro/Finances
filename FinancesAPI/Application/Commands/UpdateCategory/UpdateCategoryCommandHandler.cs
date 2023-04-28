using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<UpdateCategoryCommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        
        var entity = await _categoryRepository.GetAsync(request.Id);

        if(entity == null)
            throw new NotFoundException();

        request.Contract.Adapt(entity);

        await _categoryRepository.UpdateAsync(entity);

        var result = new UpdateCategoryCommandResult();

        return result;
    }
}