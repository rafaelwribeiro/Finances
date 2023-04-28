using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Commands.UpdateCategory;
public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResult>
{
    public int Id { get; set; }
    public CategoryUpdateContract Contract { get; set; }

    public UpdateCategoryCommand(int id, CategoryUpdateContract contract)
    {
        Id = id;
        Contract = contract;
    }
}