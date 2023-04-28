using MediatR;

namespace FinancesAPI.Application.Queries.GetCategory;

public class GetCategoryCommand : IRequest<GetCategoryCommandResult>
{
    public int Id { get; set; }
    public GetCategoryCommand(int id)
    {
        Id = id;
    }
}