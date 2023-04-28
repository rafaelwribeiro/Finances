using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
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
        var entity = await _userRepository.GetAsync(request.Id);

        if(entity == null)
            throw new NotFoundException();

        var result = new GetUserCommandResult();
        result.User = entity.Adapt<UserReadContract>();

        return result;
    }
}