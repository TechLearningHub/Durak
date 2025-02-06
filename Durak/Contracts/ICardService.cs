using Durak.Domain.Entities;

namespace Durak.Contracts;

public interface ICardService
{
    public CardEntity AddCard(CardRequest cardRequest);
}