using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Queries.ListUsers;

public class ListUsersCommandResult
{
    public IList<UserReadContract> Users { get; set; }
}
