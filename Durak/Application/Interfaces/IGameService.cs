using Durak.Contracts.Responses;

namespace Durak.Application.Interfaces;

public interface IGameService
{
    public  PlayerCardsResponse Withdraw(int playerId, int cardCount);
}