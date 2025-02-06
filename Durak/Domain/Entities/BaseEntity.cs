using Durak.Contracts;

namespace Durak.Domain.Entities;

public abstract class BaseEntity<T>
{
   public abstract long Id { get; set; } 
}