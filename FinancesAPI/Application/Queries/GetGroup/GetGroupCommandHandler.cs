using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.GetGroup;

public class GetGroupCommandHandler : IRequestHandler<GetGroupCommand, GetGroupCommandResult>
{
    private readonly IGroupRepository _groupRepository;

    public GetGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<GetGroupCommandResult> Handle(GetGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _groupRepository.GetAsync(request.Id);

        if(entity == null)
            throw new NotFoundException();

        var result = new GetGroupCommandResult();
        result.Group = entity.Adapt<GroupReadContract>();

        return result;
    }
}