using FinancesAPI.Types;

namespace FinancesAPI.Domain.Contracts;

public class CategoryUpdateContract
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public MovementType Type { get; set; }
}