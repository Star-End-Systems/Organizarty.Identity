using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

using Organizarty.Identity.Adapters.Tokens;

namespace Organizarty.Identity.Infra.Providers.Tokens;

public class JwtWebTokenProvider : IWebTokenProvider
{
    public string GenerateToken(string userId, string username, string role)
    {
        string jwtSecretKey = Environment.GetEnvironmentVariable("JWY_SECRET_KEY") ?? throw new InvalidOperationException("\"JWT Sercret key\" Not founded. Pleace check the env variable");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtSecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Role, role),
        }),
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenStr = tokenHandler.WriteToken(token) ?? throw new Exception("Fail while creating token");

        return tokenStr;
    }

    public string? ReadIdFromToken(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(jwtToken);

        var id = jsonToken.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;

        return id;
    }
}
