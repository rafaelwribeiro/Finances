using MediatR;

namespace FinancesAPI.Application.Commands.DeleteUser;
public class DeleteUserCommand : IRequest<DeleteUserCommandResult>
{
    public int Id { get; set; }
    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}