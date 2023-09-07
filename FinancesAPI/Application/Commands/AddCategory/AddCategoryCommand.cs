using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Commands.AddCategory;
public class AddCategoryCommand : IRequest<AddCategoryCommandResult>
{
    public CategoryCreateContract _contract { get; set; }
    public int OwnerId { get; set; }

    public AddCategoryCommand(CategoryCreateContract contract, int ownerId )
    {
        _contract = contract;
        OwnerId = ownerId;
    }
}