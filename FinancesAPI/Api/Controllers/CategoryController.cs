using FinancesAPI.Domain.Contracts;
using FinancesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Api.Controller;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try {
            var list = await _categoryService.GetAllAsync();
            if(list == null)
                return NotFound();

            return Ok(list);
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }

    [HttpGet("{id}", Name = "CategoryDatails")]
    public async Task<IActionResult> Get(int id)
    {
        try {
            var category = await _categoryService.GetAsync(id);
            if(category == null)
                return NotFound();

            return Ok(category);
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryCreateContract contract)
    {
        try {
            var category = await _categoryService.CreateAsync(contract);
            return CreatedAtRoute("CategoryDatails", new { Id = category.Id }, category);
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try {
            var category = await _categoryService.GetAsync(id);
            if(category == null)
                return NotFound();

            await _categoryService.Delete(id);

            return NoContent();
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(CategoryUpdateContract contract)
    {
        try {
            var category = await _categoryService.GetAsync(contract.Id);
            if(category == null)
                return NotFound();

            await _categoryService.Update(contract);

            return NoContent();
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }

}