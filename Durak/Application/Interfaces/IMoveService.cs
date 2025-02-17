using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Domain.Enums;

namespace Durak.Application.Interfaces;

public interface IMoveService
{
    public MoveResponse CreateMoveHistoryFirstPlayer(ActionTypeEnum actionTypeEnum,
        long playerId, bool isTaken, int moveCard, bool isBeaten);

    public MoveResponse CreateMoveHistorySecondPlayer(ActionTypeEnum actionTypeEnum,
        long playerId, int moveCard, bool isTaken);

    public HashSet<CardEntity> GetPFirstPlayerCards(long playerId);

    public HashSet<CardEntity> GetSecondPlayerCards(long playerId);
}