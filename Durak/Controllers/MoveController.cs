using Durak.Application.Interfaces;
using Durak.Contracts.Responses;
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
    public MoveResponse CreateMoveHistoryFirstPlayer(ActionTypeEnum actionTypeEnum, int playerId,
        bool isBeaten,
        bool isTaken, int moveCard)
    {
        return _moveService.CreateMoveHistoryFirstPlayer(actionTypeEnum, playerId, isBeaten, isTaken, moveCard);
    }
}