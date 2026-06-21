namespace Core.Shared;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }

}
