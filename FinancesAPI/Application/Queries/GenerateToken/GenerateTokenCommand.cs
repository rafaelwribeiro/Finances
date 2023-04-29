using FinancesAPI.Domain.Contracts;
using MediatR;

namespace FinancesAPI.Application.Queries.GenerateToken;

public class GenerateTokenCommand : IRequest<string>
{
    public LoginContract Contract { get; set; }
    public GenerateTokenCommand(LoginContract Contract)
    {
        this.Contract = Contract;
    }
}