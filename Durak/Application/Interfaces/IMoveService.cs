using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Domain.Enums;

namespace Durak.Application.Interfaces;

public interface IMoveService
{
    public MoveResponse CreateMoveHistoryFirstPlayer(ActionTypeEnum actionTypeEnum,
        long playerId, bool isBeaten, bool isTaken, int moveCard);

    // public MoveResponse CreateMoveHistorySecondPlayer(ActionTypeEnum actionTypeEnum,
    //     int playerId, bool isBeaten, bool isTaken);
    //
    // public MoveResponse GetMoveHistory(long moveId);
    // public MoveResponse UpdateMoveHistory(MoveRequest moveRequest, long moveId);
    // public MoveResponse DeleteMoveHistory(long moveId);
}