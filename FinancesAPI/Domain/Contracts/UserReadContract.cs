using FinancesAPI.Types;

namespace FinancesAPI.Domain.Contracts;

public class UserReadContract
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public UserStatus Status { get; set; }
}