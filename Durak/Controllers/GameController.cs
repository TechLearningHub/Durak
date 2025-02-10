using Durak.Application.Interfaces;
using Durak.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[ApiController]
[Route("[controller]")]

public class GameController: ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost]
    public PlayerCardsResponse GetPlayerCards(int playerId,int cardCount)
    {
        return  _gameService.Withdraw(playerId,cardCount);
    }
    
}