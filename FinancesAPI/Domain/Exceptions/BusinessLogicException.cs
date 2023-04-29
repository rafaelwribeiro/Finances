using System.ComponentModel;
namespace FinancesAPI.Domain.Exceptions;

public class BusinessLogicException : Exception
{
    public BusinessLogicException()
    {
    }

    public BusinessLogicException(string message): base(message)
    {
        
    }
}