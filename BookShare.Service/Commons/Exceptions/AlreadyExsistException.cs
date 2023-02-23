namespace BookShare.Service.Commons.Exceptions;

public class AlreadyExsistException : Exception
{
    public AlreadyExsistException(string message) : base(message)
    {

    }
}
