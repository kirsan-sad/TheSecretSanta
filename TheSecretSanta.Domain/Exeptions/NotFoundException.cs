namespace TheSecretSanta.Domain.Exeptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}
