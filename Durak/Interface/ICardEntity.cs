using Durak.Contracts;
using Durak.Domain.Entities;

namespace Durak.Interface;

public interface ICardEntity
{
    public CardEntity CreateCardEntity(CardRequest cardRequest);
    public CardEntity GetCardEntity(int id);
    public CardEntity UpdateCardEntity(int id, CardRequest cardRequest);
    public CardEntity DeleteCardEntity(int id);
}