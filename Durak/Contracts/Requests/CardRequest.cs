using Durak.Domain.Enums;

namespace Durak.Contracts.Requests;

public class CardRequest
{
    public SuitEnum Suit { get; set; }

    public RankEnum Rank { get; set; }  
}