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
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _mediator.Send(new ListCategoriesCommand());
        return Ok(list);
    }

    [HttpGet("{id}", Name = "CategoryDatails")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _mediator.Send(new GetCategoryCommand(id));
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryCreateContract contract)
    {
        var result = await _mediator.Send(new AddCategoryCommand(contract));
        var category = result.Category;
        return CreatedAtRoute("CategoryDatails", new { Id = category?.Id }, category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(CategoryUpdateContract contract)
    {
        await _mediator.Send(new UpdateCategoryCommand(contract.Id, contract));
        return NoContent();
    }

}