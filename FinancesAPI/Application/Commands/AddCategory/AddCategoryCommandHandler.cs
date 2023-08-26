using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.AddCategory;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, AddCategoryCommandResult>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IGroupRepository _groupRepository;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IGroupRepository groupRepository)
    {
        _categoryRepository = categoryRepository;
        _groupRepository = groupRepository;
    }

    public async Task<AddCategoryCommandResult> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity =  request._contract.Adapt<Category>();

        await VerifyGroupExists(entity);

        entity = await _categoryRepository.CreateAsync(entity);

        var result = new AddCategoryCommandResult();
        result.Category = entity.Adapt<CategoryReadContract>();

        return result;
    }

    private async Task VerifyGroupExists(Category entity)
    {
        var existingGroup = await _groupRepository.GetAsync(entity.Id);
        if(existingGroup == null)
            throw new NotFoundException("Group not exists");
    }
}