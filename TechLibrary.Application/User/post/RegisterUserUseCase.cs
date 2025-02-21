using TechLibrary.Application.User.post.Validators;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;
using TechLibrary.Domain.entities;
using TechLibrary.Exception;
using TechLibrary.Infrastructure.Repositories;
using TechLibrary.Secutirty.tokens;

namespace TechLibrary.Application.User.post
{
    public class RegisterUserUseCase
    {
        private readonly UserRepository repository;
        public UserRegisterResponseJson execute(UserRequestJson requestJson)
        {
            var generator = new JWTTokenGenerator();
            Validate(requestJson);

            var entity = new UserEntity
            {
                Email = requestJson.Email,
                Name = requestJson.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(requestJson.Password)
            };

            repository.createUser(entity);

            return new UserRegisterResponseJson
            {
                AccessToken = generator.Generate(entity),
                Name = requestJson.Name
            };
                
        }

        private void Validate(UserRequestJson request)
        {
            var validator = new RegisterUserValidator();

            var userWithEmail = repository.findByEmail(request.Email);

            if (!(userWithEmail is null))
            {
                throw new ErrorOnValidationException(["email already registered"]);
            }

            var response = validator.Validate(request);
            if (!response.IsValid) {
                var errorMessages = response.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);


            }
        }
    }
}
