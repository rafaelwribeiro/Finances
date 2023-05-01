using FinancesAPI.Types;

namespace FinancesAPI.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public int RoleId { get; set; }
    public Role? Role { get; set; }
    public UserStatus Status { get; set; } = UserStatus.WaitingApprovement;
}