using TechLibrary.Communication.Request;
using TechLibrary.Communication.Response;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Users.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestUserJson requestUserJson)
    {
        Validate(requestUserJson);

        return new ResponseRegisteredUserJson
        {

        };

    }

    private void Validate(RequestUserJson requestUserJson)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(requestUserJson);

        if (result.IsValid == false)
        {
            var errorMenssages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationsExceptions(errorMenssages);
        }

    }
}

