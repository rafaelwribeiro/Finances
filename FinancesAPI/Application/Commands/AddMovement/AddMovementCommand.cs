using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Commands.AddMovement;
public class AddMovementCommand : IRequest<AddMovementCommandResult>
{
    public string Login { get; set; }
    public MovementCreateContract Contract { get; set; }

    public AddMovementCommand(string login, MovementCreateContract contract)
    {
        Login = login;
        Contract = contract;
    }
}