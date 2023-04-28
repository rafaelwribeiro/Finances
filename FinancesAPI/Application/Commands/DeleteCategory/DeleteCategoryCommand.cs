using MediatR;

namespace FinancesAPI.Application.Commands.DeleteCategory;
public class DeleteCategoryCommand : IRequest<DeleteCategoryCommandResult>
{
    public int Id { get; set; }

    public DeleteCategoryCommand(int id)
    {
        Id = id;
    }
}