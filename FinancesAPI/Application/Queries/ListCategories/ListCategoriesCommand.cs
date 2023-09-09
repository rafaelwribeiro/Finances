using MediatR;

namespace FinancesAPI.Application.Queries.ListCategories;
public class ListCategoriesCommand : IRequest<ListCategoriesCommandResult>
{
    public int GroupId { get; set; }

    public ListCategoriesCommand(int groupId)
    {
        GroupId = groupId;
    }
}