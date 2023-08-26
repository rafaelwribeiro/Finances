using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserCommandResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IGroupRepository _groupRepository;

    public AddUserCommandHandler(IUserRepository userRepository, IGroupRepository groupRepository)
    {
        _userRepository = userRepository;
        _groupRepository = groupRepository;
    }

    public async Task<AddUserCommandResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user =  request.Adapt<User>();

        if(await _userRepository.UserNameAlreadyInUse(user.Login))
            throw new BusinessLogicException("Login is already in use");

        user = await _userRepository.CreateAsync(user);

        await CreateGroup(user);

        var result = new AddUserCommandResult();
        result.User = user.Adapt<UserReadContract>();
        return result;
    }

    private async Task CreateGroup(User user)
    {
        var group = new Group();
        group.Name = $"{user.Login}'s Group";
        group.Owner = user;
        group.OwnerId = user.Id;
        
        await _groupRepository.CreateAsync(group);
    }
}