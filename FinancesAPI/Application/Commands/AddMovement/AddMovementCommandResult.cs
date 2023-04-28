using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Commands.AddMovement;

public class AddMovementCommandResult
{
    public MovementReadContract? Movement { get; set; }
}
