using Durak.Domain.Enums;

namespace Durak.Contracts.Request;

public class CardRequest
{
    public SuitEnum Suit { get; set; }
    public RankEnum Rank { get; set; }
}