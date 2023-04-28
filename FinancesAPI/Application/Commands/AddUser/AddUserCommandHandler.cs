using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserCommandResult>
{
    private readonly IUserRepository _userRepository;

    public AddUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AddUserCommandResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user =  request.Adapt<User>();

        user = await _userRepository.CreateAsync(user);

        var result = new AddUserCommandResult();
        result.User = user.Adapt<UserReadContract>();
        return result;
    }
}