using Durak.Contracts;
using Durak.Domain.Entities;
using Durak.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController
{
    private readonly IPlayer _player;

    public PlayerController(IPlayer player) => _player = player;

    [HttpPost]
    public PlayerEntity CreatePlayer(PlayerRequest playerRequest)
    {
        return _player.CreatePlayer(playerRequest);
    }

    [HttpGet]
    public PlayerEntity GetPlayer(int playerId)
    {
        return _player.GetPlayer(playerId)!;
    }

    [HttpPut]
    public PlayerEntity UpdatePlayer(int playerId, PlayerRequest playerRequest)
    {
        return _player.UpdatePlayer(playerId, playerRequest)!;
    }

    [HttpDelete]
    public PlayerEntity DeletePlayer(int playerId)
    {
        return _player.DeletePlayer(playerId);
    }
}