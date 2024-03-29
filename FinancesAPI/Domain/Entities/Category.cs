using FinancesAPI.Types;

namespace FinancesAPI.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public MovementType Type {get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
}