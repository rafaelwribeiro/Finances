using MediatR;

namespace FinancesAPI.Application.Queries.GetGroup;

public class GetGroupCommand : IRequest<GetGroupCommandResult>
{
    public int Id { get; set; }

    public GetGroupCommand(int id)
    {
        Id = id;
    }
}