using System.IdentityModel.Tokens.Jwt;
using TechLibrary.Domain.entities;
using TechLibrary.Infrastructure.Repositories;

namespace TechLibrary.Api.service.LoggedUser
{
    public class LoggedUserService
    {
        private readonly HttpContext _context;
        public LoggedUserService(HttpContext context)
        {
            _context = context;
        }

        public string user()
        {
            var userRepository = new UserRepository();
            var authentication = _context.Request.Headers.Authorization.ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = authentication["Bearer".Length..].Trim();

            var jwtToken = tokenHandler.ReadJwtToken(token);
            return jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
        }
    }
}
