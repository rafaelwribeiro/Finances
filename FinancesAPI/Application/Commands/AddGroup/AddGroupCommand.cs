using MediatR;

namespace FinancesAPI.Application.Commands.AddGroup;
public class AddGroupCommand : IRequest<AddGroupCommandResult>
{
    public string? Name { get; set; }
    public int OwnerId { get; set; }
}