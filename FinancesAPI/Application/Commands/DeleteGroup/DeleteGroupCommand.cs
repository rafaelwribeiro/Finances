using FinancesAPI.Application.Commands.DeleteMovement;
using MediatR;

namespace FinancesAPI.Application.Commands.DeleteGroup;
public class DeleteGroupCommand : IRequest<DeleteGroupCommandResult>
{
    public int Id { get; set; }
    public DeleteGroupCommand(int id)
    {
        Id = id;
    }
}