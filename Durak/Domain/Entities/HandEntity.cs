using Durak.Contracts;

namespace Durak.Domain.Entities;

public class HandEntity : BaseEntity<long>
{
    public override long Id { get; set; }

    public PlayerEntity Player { get; set; } = new();

    public long PlayerId { get; set; }

    public List<long> CardIds { get; set; } = [];

    public DeskEntity Desk { get; set; } = new();
    
    public long DeskId { get; set; }
}