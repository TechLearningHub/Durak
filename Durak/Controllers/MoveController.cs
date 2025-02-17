using Durak.Application.Interfaces;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MoveController : ControllerBase
{
    private readonly IMoveService _moveService;

    public MoveController(IMoveService moveService)
    {
        _moveService = moveService;
    }

    [HttpPost]
    public MoveResponse CreateMoveHistoryFirstPlayer(ActionTypeEnum actionTypeEnum, long playerId,
        bool isTaken, int moveCard, bool isBeaten)
    {
        return _moveService.CreateMoveHistoryFirstPlayer(actionTypeEnum, playerId, isTaken, moveCard, isBeaten);
    }

    [HttpPost]
    public MoveResponse CreateMoveHistorySecondPlayer(ActionTypeEnum actionTypeEnum, long playerId, int moveCard,
        bool isTaken)
    {
        return _moveService.CreateMoveHistorySecondPlayer(actionTypeEnum, playerId, moveCard, isTaken);
    }

    [HttpGet]
    public HashSet<CardEntity> GetPFirstPlayerCards(long playerId)
    {
        return _moveService.GetPFirstPlayerCards(playerId);
    }

    [HttpGet]
    public HashSet<CardEntity> GetSecondPlayerCards(long playerId)
    {
        return _moveService.GetSecondPlayerCards(playerId);
    }
}