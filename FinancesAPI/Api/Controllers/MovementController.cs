using FinancesAPI.Application.Commands.AddMovement;
using FinancesAPI.Application.Commands.DeleteMovement;
using FinancesAPI.Application.Commands.UpdateMovement;
using FinancesAPI.Application.Queries.GetMovement;
using FinancesAPI.Application.Queries.ListMovements;
using FinancesAPI.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Api.Controllers;

[ApiController]
[Route("groups/{groupId}/[controller]")]
[Authorize]
public class MovementController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovementController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(int groupId)
    {
        var result = await _mediator.Send(new ListMovementsCommand());
        return Ok(result.Movements);
    }

    [HttpGet("{id}", Name = "MovementDatails")]
    public async Task<IActionResult> Get(int groupId, int id)
    {
        var result = await _mediator.Send(new GetMovementCommand(id));
        return Ok(result.Movement);
    }

    [HttpPost]
    public async Task<IActionResult> Create(int groupId, [FromBody] MovementCreateContract contract)
    {
        var result = await _mediator.Send(new AddMovementCommand(User?.Identity?.Name ?? "", contract));
        var movement = result.Movement;
        return CreatedAtRoute("MovementDatails", new { id = movement?.Id }, movement);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int groupId, int id)
    {
        var result = await _mediator.Send(new DeleteMovementCommand(id));
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(int groupId, MovementUpdateContract contract)
    {
        var result = await _mediator.Send(new UpdateMovementCommand(contract.Id, contract));
        return NoContent();
    }
}