using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BeerHub.Models;

namespace BeerHub.Utils
{
    public static class TokenGenerator
    {
        public static string GenerateJWT(FakeAuthRequest fakeAuthRequest, string secret)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var tokenHandler = new JwtSecurityTokenHandler();
            Guid userId = fakeAuthRequest.UserId.HasValue ? fakeAuthRequest.UserId.Value : Guid.NewGuid();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim("UserId", userId.ToString()),
                new(ClaimTypes.Role, fakeAuthRequest.Type.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
