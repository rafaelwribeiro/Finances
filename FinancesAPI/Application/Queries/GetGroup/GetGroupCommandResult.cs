using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Queries.GetGroup;

public class GetGroupCommandResult
{
    public GroupReadContract? Group { get; set; }
}
