using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Commands.UpdateMovement;
public class UpdateMovementCommand : IRequest<UpdateMovementCommandResult>
{
    public int Id { get; set; }
    public MovementUpdateContract Contract { get; set; }

    public UpdateMovementCommand(int id, MovementUpdateContract contract)
    {
        Id = id;
        Contract = contract;
    }
}