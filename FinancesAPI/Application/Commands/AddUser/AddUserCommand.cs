using MediatR;

namespace FinancesAPI.Application.Commands.AddUser;
public class AddUserCommand : IRequest<AddUserCommandResult>
{
    public string? Login { get; set; }
    public string? Password { get; set; }
}