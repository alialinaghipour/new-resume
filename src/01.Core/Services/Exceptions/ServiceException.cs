namespace Services.Exceptions;

public class ServiceException : Exception
{
    protected ServiceException(string message):base(message)
    {
    }

    protected ServiceException()
    {
        
    }
}