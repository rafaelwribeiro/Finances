
using FinancesAPI.Domain.Contracts;
using FinancesAPI.Infra.Repositories;
using FinancesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Api.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly IUserRepository _userRepository;
    public AccountController(TokenService tokenService, IUserRepository userRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginContract login)
    {
        var user = await _userRepository.GetByUserName(login.UserName);

        if(user == null)
            return NotFound();

        if(!user.Password.Equals(login.Password))
            return NotFound();

        var token = _tokenService.GenerateToken(user);
        return Ok(token);
    }

    //[HttpGet("user")]
    //public IActionResult GetUser() => Ok(User.Identity.Name);
    [HttpGet("author")]
    public IActionResult GetAuthor() => Ok(User.Identity.Name);
    [HttpGet("admin")]
    public IActionResult GetAdmin() => Ok(User.Identity.Name);
}
