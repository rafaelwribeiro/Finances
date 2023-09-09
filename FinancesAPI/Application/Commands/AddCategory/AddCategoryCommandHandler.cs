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
        var entity =  request.Contract.Adapt<Category>();
        entity.GroupId = request.GroupId;

        await VerifyGroupExists(request.GroupId);

        entity = await _categoryRepository.CreateAsync(entity);

        var result = new AddCategoryCommandResult();
        result.Category = entity.Adapt<CategoryReadContract>();

        return result;
    }

    private async Task VerifyGroupExists(int groupId)
    {
        var existingGroup = await _groupRepository.GetAsync(groupId);
        if(existingGroup == null)
            throw new NotFoundException("Group not exists");
    }
}