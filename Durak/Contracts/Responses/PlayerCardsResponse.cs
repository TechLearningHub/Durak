namespace Durak.Contracts.Responses;

public class PlayerCardsResponse
{
    public long Id { get; set; }
    public HashSet<long> CardIds { get; set; } = [];
}