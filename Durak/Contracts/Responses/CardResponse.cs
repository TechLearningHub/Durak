using Durak.Domain.Enums;

namespace Durak.Contracts.Responses;

public class CardResponse
{
    public long Id { get; set; }

    public SuitEnum Suit { get; set; }

    public RankEnum Rank { get; set; }
}