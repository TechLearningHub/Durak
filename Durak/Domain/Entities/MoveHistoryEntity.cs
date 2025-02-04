using Durak.Domain.Enums;

namespace Durak.Domain.Entities;

public class MoveHistoryEntity : BaseEntity<long>
{
    public override long Id { get; set; }

    public List<long> MovedCardIds { get; set; } = [];

    public string MoveId { get; set; } = string.Empty;

    public ActionTypeEnum ActionType { get; set; }

    public PlayerEntity Player { get; set; } = new();

    public long PlayerId { get; set; }

    public bool IsBeaten { get; set; }

    public bool IsTaken { get; set; }

    public List<long> BeatenCardIds { get; set; } = [];
}