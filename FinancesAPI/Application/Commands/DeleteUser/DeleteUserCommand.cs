using MediatR;

namespace FinancesAPI.Application.Commands.DeleteUser;
public class DeleteUserCommand : IRequest<DeleteUserCommandResult>
{
    public int Id { get; set; }
}