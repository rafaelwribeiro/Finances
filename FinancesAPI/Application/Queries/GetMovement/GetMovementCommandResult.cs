using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Queries.GetMovement;

public class GetMovementCommandResult
{
    public MovementReadContract? Movement { get; set; }
}
