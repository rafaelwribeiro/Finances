using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Commands.AddUser;

public class AddUserCommandResult
{
    public UserReadContract? User { get; set; }
}
