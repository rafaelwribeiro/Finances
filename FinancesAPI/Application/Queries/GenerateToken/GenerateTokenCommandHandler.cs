using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Exceptions;
using FinancesAPI.Domain.Repositories;
using FinancesAPI.Services;
using Mapster;
using MediatR;

namespace FinancesAPI.Application.Queries.GenerateToken;

public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly TokenService _tokenService;

    public GenerateTokenCommandHandler(IUserRepository userRepository, TokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var login = request.Contract;
        var user = await _userRepository.GetByUserName(login.UserName);

        if(user == null)
            throw new NotFoundException();

        if(!user.Password.Equals(login.Password))
            throw new NotFoundException();

        var token = _tokenService.GenerateToken(user);
        return token;
    }
}