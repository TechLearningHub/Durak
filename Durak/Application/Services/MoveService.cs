using Durak.Application.Interfaces;
using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Durak.Domain.Enums;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class MoveService(ApplicationDbContext context) : IMoveService
{
    private static List<long> _firstPlayerHand = new();


    public MoveResponse CreateMoveHistoryFirstPlayer(ActionTypeEnum actionTypeEnum, long playerId, bool isBeaten,
        bool isTaken, int moveCard)
    {
        if (moveCard == 0)
        {
            throw new Exception("the card never should be 0!");
        }

        var exitPlayer = context.Hands.FirstOrDefault(x => x.PlayerId == playerId);

        if (exitPlayer == null)
        {
            throw new KeyNotFoundException("player not found!");
        }

        if (_firstPlayerHand.Count <= 0)
        {
            _firstPlayerHand = exitPlayer.CardIds.ToList();
        }

        var findIndex = _firstPlayerHand[moveCard];

        return new MoveResponse();
    }
}