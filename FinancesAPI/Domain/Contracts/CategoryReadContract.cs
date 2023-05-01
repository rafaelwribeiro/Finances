using FinancesAPI.Types;

namespace FinancesAPI.Domain.Contracts;

public class CategoryReadContract
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public MovementType Type { get; set; }
}