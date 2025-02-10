using Durak.Application.Interfaces;
using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

    [ApiController]
    [Route("[controller]")]
public class PlayerController: ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpPost]
    public PlayerResponse AddPlayer(PlayerRequest playerRequest)
    {
      return  _playerService.AddPlayer(playerRequest);
    }

    [HttpGet]
    public PlayerResponse? GetPlayerById(int playerId)
    {
      return  _playerService.GetPlayerById(playerId);
    }

    [HttpDelete]
    public void DeletePlayer(int playerId)
    {
      _playerService.DeletePlayerById(playerId);
       
    }

    [HttpPut]
    public PlayerResponse? UpdatePlayer(PlayerRequest playerRequest,int playerId)
    {
       return _playerService.UpdatePlayer(playerId, playerRequest);
    }
}