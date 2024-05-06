using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JwtBearerImplementation.Models;
using Microsoft.IdentityModel.Tokens;

namespace JwtBearerImplementation.Services.Auth;

public class TokenServices
{
    public string generateToken(Users users)
    {
        var key = Encoding.ASCII.GetBytes(Key.privateToken);

        var credentials =  new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
            );

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2)
        };
        
        
        var handler = new JwtSecurityTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    private static ClaimsIdentity generateClaims(Users users)
    {
        var ci = new ClaimsIdentity();
        ci.AddClaim(new Claim(ClaimTypes.Name, users.Name));
        foreach (var role in users.Roles)
            ci.AddClaim(new Claim(ClaimTypes.Role, role));

        return ci;
    }
}