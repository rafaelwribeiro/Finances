using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Queries.ListGroups;

public class ListGroupsCommandResult
{
    public IList<GroupReadContract>? Groups { get; set; }
}
