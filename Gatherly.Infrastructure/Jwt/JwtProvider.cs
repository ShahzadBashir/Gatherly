using Gatherly.Application.Contracts.Infrastructure.Jwt;
using Gatherly.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gatherly.Infrastructure.Jwt;

internal sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;

    public JwtProvider(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public string Generate(Member member)
    {
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,member.Id.Value.ToString()),
            new(JwtRegisteredClaimNames.Email,member.EmailAddress)
        };

        var signInCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddMinutes(5),
            signInCredentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}
