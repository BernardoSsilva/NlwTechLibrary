using TechLibrary.Application.User.post.Validators;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;
using TechLibrary.Exception;
using TechLibrary.Infrastructure.entities;
using TechLibrary.Infrastructure.Repositories;

namespace TechLibrary.Application.User.post
{
    public class RegisterUserUseCase
    {
        private readonly UserRepository repository;
        public UserRegisterResponseJson execute(UserRequestJson requestJson)
        {
            Validate(requestJson);

            var entity = new UserEntity
            {
                Email = requestJson.Email,
                Name = requestJson.Name,
                Password = requestJson.Password
            };

            repository.createUser(entity);

            return new UserRegisterResponseJson
            {
                AccessToken = "",
                Email = requestJson.Email,
                Name = requestJson.Name
            };
                
        }

        private void Validate(UserRequestJson request)
        {
            var validator = new RegisterUserValidator();

            var response = validator.Validate(request);
            if (!response.IsValid) {
                var errorMessages = response.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);


            }
        }
    }
}
