namespace Durak.Contracts.Request;

public class GameRequest
{
    public long Id { get; set; }
    public List<long> CardIds { get; set; }
}