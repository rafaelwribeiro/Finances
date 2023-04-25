using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Commands.AddUser;

public class ListUsersCommandResult
{
    public IList<UserReadContract> Users { get; set; }
}
