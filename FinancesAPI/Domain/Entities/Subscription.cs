namespace FinancesAPI.Domain.Entities;
public class Subscription
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
}