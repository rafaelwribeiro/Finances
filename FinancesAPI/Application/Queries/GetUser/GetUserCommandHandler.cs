using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Infra.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.GetUser;

public class GetUserCommandHandler : IRequestHandler<GetUserCommand, GetUserCommandResult>
{
    private readonly IUserRepository _userRepository;

    public GetUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserCommandResult> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id);

        var result = new GetUserCommandResult();
        result.User = user.Adapt<UserReadContract>();

        return result;
    }
}