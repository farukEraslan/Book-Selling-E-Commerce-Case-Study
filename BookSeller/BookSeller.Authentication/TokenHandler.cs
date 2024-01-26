using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookSeller.Authentication
{
    public static class TokenHandler
    {
        public static Token CreateToken(this IConfiguration configuration)
        {
            var token = new Token();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.ExpirationTime = DateTime.Now.AddMinutes(Convert.ToInt16(configuration["Token:ExpirationTime"]));

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["Token:Issuer"],
                audience: configuration["Token:Audience"],
                expires: token.ExpirationTime,
                notBefore: DateTime.Now,
                signingCredentials: credentials
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);
            return token;
            
        }
    }
}
