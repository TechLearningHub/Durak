using Durak.Contracts;
using Durak.Domain.Entities;

namespace Durak.Interface;

public interface ICardEntity
{
    public CardEntity CreateCardEntity(CardRequest cardRequest);
    public CardEntity GetCardEntity();
    public CardEntity UpdateCardEntity();
    public CardEntity DeleteCardEntity();
}