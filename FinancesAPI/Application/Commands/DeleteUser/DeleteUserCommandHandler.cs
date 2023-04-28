using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandResult>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<DeleteUserCommandResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user =  request.Adapt<User>();

        user = await _userRepository.GetAsync(request.Id);
        if(user == null)
            throw new NotFoundException();

        await _userRepository.DeleteAsync(user);

        var result = new DeleteUserCommandResult();

        return result;
    }
}