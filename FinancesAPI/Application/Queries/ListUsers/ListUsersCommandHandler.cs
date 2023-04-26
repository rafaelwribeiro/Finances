using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Infra.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.ListUsers;

public class ListUsersCommandHandler : IRequestHandler<ListUsersCommand, ListUsersCommandResult>
{
    private readonly IUserRepository _userRepository;

    public ListUsersCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ListUsersCommandResult> Handle(ListUsersCommand request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();

        var result = new ListUsersCommandResult();
        result.Users = users.Adapt<IList<UserReadContract>>();

        return result;
    }
}