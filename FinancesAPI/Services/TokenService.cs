using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using FinancesAPI.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace FinancesAPI.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        if(user == null)
            return "";
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.Name, user.Login), //User.Identity.Name
                //new (ClaimTypes.Role, user.Role.Name)//User.IsInRole
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}