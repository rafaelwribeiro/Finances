using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResult>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UpdateUserCommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        
        var user = await _userRepository.GetAsync(request.Id);

        request.contract.Adapt(user);

        await _userRepository.UpdateAsync(user);

        var result = new UpdateUserCommandResult();

        return result;
    }
}