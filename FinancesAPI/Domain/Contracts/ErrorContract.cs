namespace FinancesAPI.Domain.Contracts;

public class ErrorContract
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = "";
}