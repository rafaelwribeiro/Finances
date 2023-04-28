using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Queries.ListCategories;

public class ListCategoriesCommandResult
{
    public IList<CategoryReadContract>? Categories { get; set; }
}
