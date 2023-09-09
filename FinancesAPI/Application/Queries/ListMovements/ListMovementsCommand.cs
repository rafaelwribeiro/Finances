using MediatR;

namespace FinancesAPI.Application.Queries.ListMovements;
public class ListMovementsCommand : IRequest<ListMovementsCommandResult>
{
    public int GroupId { get; set; }
    public ListMovementsCommand(int groupId)
    {
        GroupId = groupId;
    }
}