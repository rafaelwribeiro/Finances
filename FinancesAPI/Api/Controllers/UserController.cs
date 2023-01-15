using FinancesAPI.Api.Contracts;
using FinancesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try {
            var list = await _userService.GetAllAsync();
            if(list == null)
                return NotFound();

            return Ok(list);
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateContract contract)
    {
        try {
            var user = await _userService.CreateAsync(contract);
            return CreatedAtRoute("UserDatails", new { Id = user.Id }, user);
        } catch(Exception ex) {
            return StatusCode(500, $" Erro -->.. {ex.Message}");
        }
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