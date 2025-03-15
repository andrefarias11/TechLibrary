using System.Net;

namespace TechLibrary.Exception;

public class ErrorOnValidationsExceptions : TechLibraryException
{
    private readonly List<string> _errors;

    public ErrorOnValidationsExceptions(List<string> errorsMenssages)
    {
        _errors = errorsMenssages;
    }
    public override List<string> GetErrorMenssages() => _errors;

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;

}

