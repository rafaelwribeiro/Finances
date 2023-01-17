using FinancesAPI.Api.Contracts;
using FinancesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovementController : ControllerBase
{
    private readonly IMovementService _movementService;

    public MovementController(IMovementService movementService) => _movementService = movementService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try {
            var list = await _movementService.GetAllAsync();
            if(list == null)
                return NotFound();

            return Ok(list);
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }

    [HttpGet("{id}", Name = "MovementDatails")]
    public async Task<IActionResult> Get(int id)
    {
        try {
            var movement = await _movementService.GetAsync(id);
            if(movement == null)
                return NotFound();

            return Ok(movement);
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MovementCreateContract contract)
    {
        try {
            var movement = await _movementService.CreateAsync(contract);
            return CreatedAtRoute("MovementDatails", new { Id = movement.Id }, movement);
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try {
            var movement = await _movementService.GetAsync(id);
            if(movement == null)
                return NotFound();

            await _movementService.Delete(id);

            return NoContent();
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(MovementUpdateContract contract)
    {
        try {
            var movement = await _movementService.GetAsync(contract.Id);
            if(movement == null)
                return NotFound();

            await _movementService.Update(contract);

            return NoContent();
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
    }
}