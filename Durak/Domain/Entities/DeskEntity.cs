using Durak.Contracts;

namespace Durak.Domain.Entities;

public class DeskEntity : BaseEntity<long>
{
    public override long Id { get; set; }

    public List<HandEntity> Hands { get; set; } = [];

    public string Winner { get; set; } = string.Empty;

    public long CardId { get; set; }
}