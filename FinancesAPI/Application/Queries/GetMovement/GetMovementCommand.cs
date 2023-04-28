using MediatR;

namespace FinancesAPI.Application.Queries.GetMovement;

public class GetMovementCommand : IRequest<GetMovementCommandResult>
{
    public int Id { get; set; }
    public GetMovementCommand(int id)
    {
        Id = id;
    }
}