using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.ListCategories;

public class ListCategoriesCommandHandler : IRequestHandler<ListCategoriesCommand, ListCategoriesCommandResult>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IGroupRepository _groupRepository;

    public ListCategoriesCommandHandler(ICategoryRepository categoryRepository, IGroupRepository groupRepository)
    {
        _categoryRepository = categoryRepository;
        _groupRepository = groupRepository;
    }

    public async Task<ListCategoriesCommandResult> Handle(ListCategoriesCommand request, CancellationToken cancellationToken)
    {
        var entities = await _categoryRepository.GetAllByGroupAsync(request.GroupId);

        await VerifyIfGroupExists(request.GroupId);

        var result = new ListCategoriesCommandResult();
        result.Categories = entities.Adapt<IList<CategoryReadContract>>();

        return result;
    }

    private async Task VerifyIfGroupExists(int groupId)
    {
        var group = await _groupRepository.GetAsync(groupId);
        if(group is null)
            throw new NotFoundException("Group not found");
    }
}