using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Commands.UpdateUser;
public class UpdateUserCommand : IRequest<UpdateUserCommandResult>
{
    public int Id { get; set; }
    public UserUpdateContract Contract { get; set; }

    public UpdateUserCommand(int id, UserUpdateContract contract)
    {
        Id = id;
        Contract = contract;
    }
}