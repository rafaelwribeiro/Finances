using System.Security.Claims;
using FinancesAPI.Application.Commands.AddGroup;
using FinancesAPI.Application.Queries.ListGroups;
using FinancesAPI.Domain.Contracts;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Api.Controller;

[ApiController]
[Authorize]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly IMediator _mediator;
    public GroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _mediator.Send(new ListGroupsCommand());
        return Ok(list);
    }

    [HttpGet("{id}", Name = "GroupDatails")]
    public async Task<IActionResult> Get(int id)
    {
        //var category = await _mediator.Send(new GetGroupCommand(id));
        //return Ok(category);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GroupCreateContract contract)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var command = contract.Adapt<AddGroupCommand>();
        command.OwnerId = int.Parse(userId ?? "0");
        var result = await _mediator.Send(command);

        var group = result.Group;
        return CreatedAtRoute("GroupDatails", new { Id = group?.Id }, group);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        //await _mediator.Send(new DeleteGroupCommand(id));
        return NoContent();
    }

    /*[HttpPut]
    public async Task<IActionResult> Update(CategoryUpdateContract contract)
    {
        await _mediator.Send(new UpdateCategoryCommand(contract.Id, contract));
        return NoContent();
    }*/

}