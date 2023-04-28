using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Queries.GetCategory;

public class GetCategoryCommandResult
{
    public CategoryReadContract? Category { get; set; }
}
