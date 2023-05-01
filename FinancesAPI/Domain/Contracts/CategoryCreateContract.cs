using FinancesAPI.Types;

namespace FinancesAPI.Domain.Contracts;

public class CategoryCreateContract
{
    public string? Name { get; set; }
    public MovementType Type { get; set; }
}