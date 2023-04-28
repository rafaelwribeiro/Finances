using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Queries.ListMovements;

public class ListMovementsCommandResult
{
    public IList<MovementReadContract>? Movements { get; set; }
}
