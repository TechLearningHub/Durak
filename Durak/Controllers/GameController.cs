using Durak.Application.Interfaces;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService) => _gameService = gameService;

    [HttpPost]
    public List<CardEntity>? Withdraw(int playerId, long deskId)
    {
        return _gameService.Withdraw(playerId, deskId);
    }
}