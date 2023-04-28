using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Commands.AddMovement;
public class AddMovementCommand : IRequest<AddMovementCommandResult>
{
    public MovementCreateContract _contract { get; set; }

    public AddMovementCommand(MovementCreateContract contract)
    {
        _contract = contract;
    }
}