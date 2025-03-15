using FluentValidation;
using TechLibrary.Api.Language;
using TechLibrary.Communication.Request;

namespace TechLibrary.Api.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage(ErrorMenssage.EXC0001);
        RuleFor(request => request.Email).NotEmpty().WithMessage(ErrorMenssage.EXC0002);
        RuleFor(request => request.Password).NotEmpty().WithMessage(ErrorMenssage.EXC0003);

        When(request => string.IsNullOrEmpty(request.Password) == false, () =>
        {
            RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ErrorMenssage.EXC0004);
        });
    }


}

