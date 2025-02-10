namespace Durak.Domain.Entities;

public class HandEntity : BaseEntity<long>
{
    public override long Id { get; set; } //ignore

    public PlayerEntity Player { get; set; } = new(); //ignore

    public long PlayerId { get; set; }

    public List<long> CardIds { get; set; } = []; //ignore
    
    public DeskEntity Desk { get; set; } = new(); //ignore
    
    public long DeskId { get; set; }
}