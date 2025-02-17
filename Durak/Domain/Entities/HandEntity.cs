namespace Durak.Domain.Entities;

public class HandEntity : BaseEntity<long>
{
    public override long Id { get; set; }

    public PlayerEntity Player { get; set; }
    
    public long PlayerId { get; set; }
    
    public List<long> CardIds { get; set; } = [];

    public DeskEntity Desk { get; set; }
    
    public long DeskId { get; set; }
}