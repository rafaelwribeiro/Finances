using MediatR;

namespace FinancesAPI.Application.Commands.DeleteMovement;
public class DeleteMovementCommand : IRequest<DeleteMovementCommandResult>
{
    public int Id { get; set; }
    public DeleteMovementCommand(int id)
    {
        Id = id;
    }
}