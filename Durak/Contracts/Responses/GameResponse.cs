namespace Durak.Contracts.Responses;

public class GameResponse
{
    public long Id { get; set; }
    public HashSet<long> CardIds { get; set; } = [];
}