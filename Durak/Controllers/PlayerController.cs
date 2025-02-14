using Durak.Application.Interfaces;
using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpPost]
    public void Post(PlayerRequest playerRequest)
    {
        _playerService.AddPlayer(playerRequest);
    }

    [HttpGet]
    public PlayerResponse? Get(int playerId)
    {
        return _playerService.GetPlayerById(playerId);
    }

    [HttpDelete]
    public void DeletePlayer(int playerId)
    {
        _playerService.DeletePlayerById(playerId);
    }

    [HttpPut]
    public void Put(PlayerRequest playerRequest, int playerId)
    {
        _playerService.UpdatePlayer(playerId, playerRequest);
    }
}