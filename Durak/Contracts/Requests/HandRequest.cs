namespace Durak.Contracts.Requests;

public class HandRequest
{
    public long PlayerId { get; set; }
    
    public long DeskId { get; set; }
    
    public List<long> CardIds { get; set; } = [];
}