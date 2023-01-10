using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Api.Controller;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok("lista");
    }
}