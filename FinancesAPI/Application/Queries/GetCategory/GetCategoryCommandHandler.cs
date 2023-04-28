using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.GetCategory;

public class GetCategoryCommandHandler : IRequestHandler<GetCategoryCommand, GetCategoryCommandResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoryCommandResult> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _categoryRepository.GetAsync(request.Id);

        if(entity == null)
            throw new NotFoundException();

        var result = new GetCategoryCommandResult();
        result.Category = entity.Adapt<CategoryReadContract>();

        return result;
    }
}