using MediatR;

namespace FinancesAPI.Application.Queries.GetUser;

public class GetUserCommand : IRequest<GetUserCommandResult>
{
    public int Id { get; set; }
}