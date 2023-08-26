using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Commands.AddGroup;

public class AddGroupCommandResult
{
    public GroupReadContract? Group { get; set; }
}
