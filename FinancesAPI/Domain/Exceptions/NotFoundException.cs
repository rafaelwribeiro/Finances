namespace FinancesAPI.Domain.Exceptions;

public class NotFoundException : Exception
{
    public string? NotFoundMessage { get; set; }
    public NotFoundException()
    {
        
    }
    public NotFoundException(string notFoundMessage)
     => this.NotFoundMessage = notFoundMessage;
}