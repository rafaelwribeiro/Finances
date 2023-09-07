using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.ListGroups;

public class ListGroupsCommandHandler : IRequestHandler<ListGroupsCommand, ListGroupsCommandResult>
{
    private readonly IGroupRepository _groupRepository;

    public ListGroupsCommandHandler(IGroupRepository categoryRepository)
    {
        _groupRepository = categoryRepository;
    }

    public async Task<ListGroupsCommandResult> Handle(ListGroupsCommand request, CancellationToken cancellationToken)
    {
        var entities = await _groupRepository.GetAllAsync();

        var result = new ListGroupsCommandResult();
        result.Groups = entities.Adapt<IList<GroupReadContract>>();

        return result;
    }
}