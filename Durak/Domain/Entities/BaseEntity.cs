namespace Durak.Domain.Entities;

public abstract class BaseEntity<T>
{
    public abstract T Id { get; set; }
}