using FinancesAPI.Types;

namespace FinancesAPI.Domain.Contracts;

public class MovementReadContract
{
    public int Id { get; set; }
    public DateTime? Date { get; set; }
    public decimal? Value { get; set; }
    public string? Description { get; set; }
    public MovementType Type {get; set; }
    public CategoryReadContract? Category { get; set; }
    public UserReadContract? User { get; set; }
}