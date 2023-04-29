
using FinancesAPI.Application.Queries.GenerateToken;
using FinancesAPI.Domain.Contracts;
using FinancesAPI.Domain.Repositories;
using FinancesAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Api.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginContract login)
    {
        var token = await _mediator.Send(new GenerateTokenCommand(login));
        return Ok(token);
    }
}
