using FinancesAPI.Application.Commands.AddUser;
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
        try {
            var user = await _userService.GetAsync(id);
            if(user == null)
                return NotFound();

            return Ok(user);
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
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
        try {
            var user = await _userService.GetAsync(id);
            if(user == null)
                return NotFound();

            await _userService.Delete(id);

            return NoContent();
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(UserUpdateContract contract)
    {
        try {
            var user = await _userService.GetAsync(contract.Id);
            if(user == null)
                return NotFound();

            await _userService.Update(contract);

            return NoContent();
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }
}