using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Commands.AddCategory;
public class AddCategoryCommand : IRequest<AddCategoryCommandResult>
{
    public CategoryCreateContract Contract { get; set; }
    public int GroupId { get; set; }

    public AddCategoryCommand(CategoryCreateContract contract, int groupId)
    {
        Contract = contract;
        GroupId = groupId;
    }
}