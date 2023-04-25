namespace FinancesAPI.Domain.Contracts;

public class UserUpdateContract
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
}