using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Commands.UpdateGroup;
public class UpdateGroupCommand : IRequest<UpdateGroupCommandResult>
{
    public int Id { get; set; }
    public GroupUpdateContract Contract { get; set; }

    public UpdateGroupCommand(int id, GroupUpdateContract contract)
    {
        Id = id;
        Contract = contract;
    }
}