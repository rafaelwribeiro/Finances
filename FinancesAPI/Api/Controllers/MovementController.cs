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
[Route("[controller]")]
[Authorize]
public class MovementController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovementController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _mediator.Send(new ListMovementsCommand());
        return Ok(list);
    }

    [HttpGet("{id}", Name = "MovementDatails")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetMovementCommand(id));
        return Ok(result.Movement);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MovementCreateContract contract)
    {
        var result = await _mediator.Send(new AddMovementCommand(contract));
        var movement = result.Movement;
        return CreatedAtRoute("MovementDatails", new { Id = movement?.Id }, movement);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteMovementCommand(id));
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(MovementUpdateContract contract)
    {
        var result = await _mediator.Send(new UpdateMovementCommand(contract.Id, contract));
        return NoContent();
    }
}