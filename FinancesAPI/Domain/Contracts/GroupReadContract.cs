namespace FinancesAPI.Domain.Contracts;

public class GroupReadContract
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public UserReadContract Owner { get; set; }
}