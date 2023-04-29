using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.AddCategory;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, AddCategoryCommandResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<AddCategoryCommandResult> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity =  request._contract.Adapt<Category>();

        entity = await _categoryRepository.CreateAsync(entity);

        var result = new AddCategoryCommandResult();
        result.Category = entity.Adapt<CategoryReadContract>();

        return result;
    }
}