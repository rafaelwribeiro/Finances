using FinancesAPI.Types;

namespace FinancesAPI.Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public User Owner { get; set; }
    public int OwnerId { get; set; }
    public GroupStatus Status { get; set; } = GroupStatus.Active;
    public ICollection<Subscription> Subscriptions { get; set; }
}