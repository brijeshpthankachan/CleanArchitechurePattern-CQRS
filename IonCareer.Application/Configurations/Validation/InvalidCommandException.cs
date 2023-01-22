namespace IonCareer.Application.Configurations.Validation;

public class InvalidCommandException : Exception
{
    public InvalidCommandException(string message, string details) : base(message)
    {
        Details = details;
    }

    private string Details { get; }
}