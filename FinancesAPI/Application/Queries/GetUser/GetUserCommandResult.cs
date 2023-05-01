using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Queries.GetUser;

public class GetUserCommandResult
{
    public UserReadContract? User { get; set; }
}
