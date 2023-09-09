using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.UpdateGroup;

public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, UpdateGroupCommandResult>
{
    private readonly IGroupRepository _groupRepository;

    public UpdateGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<UpdateGroupCommandResult> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _groupRepository.GetAsync(request.Id);

        if(entity == null)
            throw new NotFoundException();

        request.Contract.Adapt(entity);

        await _groupRepository.UpdateAsync(entity);

        return new UpdateGroupCommandResult();
    }
}