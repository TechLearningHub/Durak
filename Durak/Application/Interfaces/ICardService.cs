using Durak.Contracts.Requests;
using Durak.Contracts.Responses;

namespace Durak.Application.Interfaces;

public interface ICardService
{
    public CardResponse AddCard(CardRequest cardRequest);
    public CardResponse? GetCard(int cardId);
    public CardResponse UpdateCard(int cardId, CardRequest cardRequest);
    public CardResponse DeleteCard(int cardId);
}