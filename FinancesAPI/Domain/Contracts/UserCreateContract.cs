namespace FinancesAPI.Domain.Contracts;

public class UserCreateContract
{
    public string? Login { get; set; }
    public string? Password { get; set; }
}