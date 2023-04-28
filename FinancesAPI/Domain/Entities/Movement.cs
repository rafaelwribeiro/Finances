using FinancesAPI.Domain.Entities;
using FinancesAPI.Types;

namespace FinancesAPI.Domain.Entities;

public class Movement
{
    public int Id { get; set; }
    public DateTime? Date { get; set; }
    public decimal? Value { get; set; }
    public string? Description { get; set; }
    public MovementType Type {get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}