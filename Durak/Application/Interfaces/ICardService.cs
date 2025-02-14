using Durak.Contracts.Request;
using Durak.Contracts.Responses;

namespace Durak.Application.Interfaces;

public interface ICardService
{
    public CardResponse AddCard();
    public CardResponse? GetCard(long cardId);
    public CardResponse UpdateCard(int cardId, CardRequest cardRequest);
    public CardResponse DeleteCard(int cardId);
}