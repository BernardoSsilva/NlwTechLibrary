using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;
using TechLibrary.Exception;
using TechLibrary.Infrastructure.Repositories;
using TechLibrary.Secutirty.tokens;

namespace TechLibrary.Application.User.post
{
    public class LoginUseCase
    {

        public UserRegisterResponseJson execute(RequestLoginJson request)
        {
            var userRepository = new UserRepository();

            var user = userRepository.findByEmail(request.Email);



            if(user is null)
            {
                throw new InvalidLoginException();
            }

            var passwordIsSame = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);


            if (!passwordIsSame)
            {
                throw new InvalidLoginException();
            }

            var jwtGenerator = new JWTTokenGenerator();

            return new UserRegisterResponseJson
            {
                AccessToken = jwtGenerator.Generate(user),
                Name = user.Name,
            };
        }

    }
}
