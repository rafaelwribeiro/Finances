using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Commands.AddMovement;
public class AddMovementCommand : IRequest<AddMovementCommandResult>
{
    public string Login { get; set; }
    public int GroupId { get; set; }
    public MovementCreateContract Contract { get; set; }

    public AddMovementCommand(string login, int groupId, MovementCreateContract contract)
    {
        Login = login;
        Contract = contract;
        GroupId = groupId;
    }
}