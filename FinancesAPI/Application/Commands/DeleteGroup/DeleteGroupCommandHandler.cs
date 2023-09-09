using FinancesAPI.Application.Commands.DeleteMovement;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.DeleteGroup;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, DeleteGroupCommandResult>
{
    private readonly IGroupRepository _groupRepository;

    public DeleteGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<DeleteGroupCommandResult> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var entity =  request.Adapt<Group>();

        entity = await _groupRepository.GetAsync(request.Id);
        if(entity == null)
            throw new NotFoundException();

        await _groupRepository.DeleteAsync(entity);

        return new DeleteGroupCommandResult();
    }
}