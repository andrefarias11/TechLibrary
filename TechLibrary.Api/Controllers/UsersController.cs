using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.Language;
using TechLibrary.Api.UseCases.Users.Register;
using TechLibrary.Communication.Request;
using TechLibrary.Communication.Response;
using TechLibrary.Exception;

namespace TechLibrary.Api.Controllers;

[Route("[controller]")]
[ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
[ProducesResponseType(typeof(ResponseErrorMenssagesJson), StatusCodes.Status400BadRequest)]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(RequestUserJson requestUserJson)
    {
        try
        {
            RegisterUserUseCase useCase = new RegisterUserUseCase();

            var response = useCase.Execute(requestUserJson);

            return Created(string.Empty, response);

        }
        catch(TechLibraryException ex)
        {
            return BadRequest(new ResponseErrorMenssagesJson
            {
                Errors = ex.GetErrorMenssages()
            });
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMenssagesJson
            {
                Errors = [ErrorMenssage.EXC0005]
            }); 
        }
    }
}