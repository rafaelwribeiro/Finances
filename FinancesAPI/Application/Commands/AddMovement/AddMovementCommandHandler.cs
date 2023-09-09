using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Commands.AddMovement;

public class AddMovementCommandHandler : IRequestHandler<AddMovementCommand, AddMovementCommandResult>
{
    private readonly IMovementRepository _movementRepository;
    private readonly IUserRepository _userRepository;

    public AddMovementCommandHandler(IMovementRepository movementRepository, IUserRepository userRepository)
    {
        _movementRepository = movementRepository;
        _userRepository = userRepository;
    }

    public async Task<AddMovementCommandResult> Handle(AddMovementCommand request, CancellationToken cancellationToken)
    {
        var entity =  request.Contract.Adapt<Movement>();
        entity.GroupId = request.GroupId;

        entity.User = await SolveUser(request.Login);

        entity = await _movementRepository.CreateAsync(entity);

        var result = new AddMovementCommandResult();
        result.Movement = entity.Adapt<MovementReadContract>();
        return result;
    }

    private async Task<User> SolveUser(string login)
    {
        var user = await _userRepository.GetByUserName(login);
        if(user == null)
            throw new BusinessLogicException("User not found for this operation");
        return user;
    }
}