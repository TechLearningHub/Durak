using Durak.Contracts.Request;
using Durak.Contracts.Responses;

namespace Durak.Application.Interfaces;

public interface ICard
{
    public CardResponse AddCard(CardRequest cardRequest);
    public CardResponse GetCard(int cardId);
    public CardResponse UpdateCard(int cardId, CardRequest cardRequest);
    public CardResponse DeleteCard(int cardId);
}