using Durak.Domain.Enums;

namespace Durak.Domain.Entities;

public class CardEntity : BaseEntity<long>
{
    public override long Id { get; set; }

    public SuitEnum Suit { get; set; }

    public RankEnum Rank { get; set; }
}