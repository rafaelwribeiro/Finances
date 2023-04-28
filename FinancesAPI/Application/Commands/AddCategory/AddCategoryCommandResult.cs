using FinancesAPI.Domain.Contracts;

namespace FinancesAPI.Application.Commands.AddCategory;

public class AddCategoryCommandResult
{
    public CategoryReadContract? Category { get; set; }
}
