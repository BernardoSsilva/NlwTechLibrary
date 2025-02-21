using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechLibrary.Domain.entities;

namespace TechLibrary.Secutirty.tokens
{
    public class JWTTokenGenerator
    {
        public string Generate(UserEntity user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(2400),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new System.Security.Claims.ClaimsIdentity(claims)
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private static SymmetricSecurityKey SecurityKey()
        {
            var signingKey = "be6e3783-5e05-40ba-8460-1b3c88c5afba";
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        }
    }
}
