using FinancesAPI.Types;

namespace FinancesAPI.Domain.Contracts;

public class MovementCreateContract
{
    public DateTime? Date { get; set; }
    public decimal? Value { get; set; }
    public string? Description { get; set; }
    public MovementType Type {get; set; }
    public int CategoryId { get; set; }
}