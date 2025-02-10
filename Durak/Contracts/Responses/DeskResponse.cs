namespace Durak.Contracts.Responses;

public class DeskResponse
{
    public  long Id { get; set; }

    public string Winner { get; set; } = string.Empty;

    public long CardId { get; set; }
}