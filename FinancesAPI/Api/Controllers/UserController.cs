using FinancesAPI.Application.Commands.AddUser;
using FinancesAPI.Application.Commands.DeleteUser;
using FinancesAPI.Application.Commands.UpdateUser;
using FinancesAPI.Application.Queries.GetUser;
using FinancesAPI.Application.Queries.ListUsers;
using FinancesAPI.Domain.Contracts;
using FinancesAPI.Services;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMediator _mediator;

    public UserController(IUserService userService, IMediator mediator)
    {
        _userService = userService;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new ListUsersCommand());
        return Ok(result.Users);
    }

    [HttpGet("{id}", Name = "UserDatails")]
    public async Task<IActionResult> Get(int id)
    {
        var command = new GetUserCommand();
        command.Id = id;
        var result = await _mediator.Send(command);
        return Ok(result.User);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateContract contract)
    {
        var result = await _mediator.Send(contract.Adapt<AddUserCommand>());
        return Ok(result.User);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand();
        command.Id = id;
        var result = await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UserUpdateContract contract)
    {
        var command = new UpdateUserCommand();
        command.Id = contract.Id;
        command.contract = contract;
        var result = await _mediator.Send(command);
        return NoContent();
    }
}