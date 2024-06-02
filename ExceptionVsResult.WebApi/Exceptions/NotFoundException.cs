namespace ExceptionVsResult.WebApi.Exceptions
{
    public class NotFoundException(string message) : Exception(message);
}
