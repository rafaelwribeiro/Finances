using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Commands.UpdateUser;
public class UpdateUserCommand : IRequest<UpdateUserCommandResult>
{
    public int Id { get; set; }
    public UserUpdateContract contract { get; set; }
}