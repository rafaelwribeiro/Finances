using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.AddGroup;

public class AddGroupCommandHandler : IRequestHandler<AddGroupCommand, AddGroupCommandResult>
{
    private readonly IGroupRepository _groupRepository;

    public AddGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<AddGroupCommandResult> Handle(AddGroupCommand request, CancellationToken cancellationToken)
    {
        var group = request.Adapt<Group>();

        group = await _groupRepository.CreateAsync(group);

        var result = new AddGroupCommandResult();
        result.Group = group.Adapt<GroupReadContract>();
        return result;
    }
}