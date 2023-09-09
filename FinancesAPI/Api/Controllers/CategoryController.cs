using System.Security.Claims;
using FinancesAPI.Application.Commands.AddCategory;
using FinancesAPI.Application.Commands.DeleteCategory;
using FinancesAPI.Application.Commands.UpdateCategory;
using FinancesAPI.Application.Queries.GetCategory;
using FinancesAPI.Application.Queries.ListCategories;
using FinancesAPI.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Api.Controller;

[ApiController]
[Authorize]
[Route("groups/{groupId}/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int groupId)
    {
        var result = await _mediator.Send(new ListCategoriesCommand(groupId));
        return Ok(result.Categories);
    }

    [HttpGet("{id}", Name = "CategoryDatails")]
    public async Task<IActionResult> Get(int groupId, int id)
    {
        var category = await _mediator.Send(new GetCategoryCommand(id));
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(int groupId, [FromBody] CategoryCreateContract contract)
    {
        
        var result = await _mediator.Send(new AddCategoryCommand(contract, groupId));
        var category = result.Category;
        return CreatedAtRoute("CategoryDatails", new {groupId = category?.GroupId,  id = category?.Id }, category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int groupId, int id)
    {
        await _mediator.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(int groupId, CategoryUpdateContract contract)
    {
        await _mediator.Send(new UpdateCategoryCommand(contract.Id, contract));
        return NoContent();
    }

}