using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.ListCategories;

public class ListCategoriesCommandHandler : IRequestHandler<ListCategoriesCommand, ListCategoriesCommandResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public ListCategoriesCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<ListCategoriesCommandResult> Handle(ListCategoriesCommand request, CancellationToken cancellationToken)
    {
        var entities = await _categoryRepository.GetAllAsync();

        var result = new ListCategoriesCommandResult();
        result.Categories = entities.Adapt<IList<CategoryReadContract>>();

        return result;
    }
}