namespace Durak.Domain.Entities;

public class PlayerEntity : BaseEntity<long>
{
    public override long Id { get; set; }

    public string NickName { get; set; } = string.Empty;
}