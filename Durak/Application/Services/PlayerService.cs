using Durak.Application.Interfaces;
using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class PlayerService(ApplicationDbContext context) : IPlayerService
{
    private readonly ApplicationDbContext _context = context;

    public PlayerResponse AddPlayer(PlayerRequest playerRequest)
    {
        var player = new PlayerEntity
        {
            NickName = playerRequest.NickName
        };

        var playerEntity = _context.Players.Add(player).Entity;
        _context.SaveChanges();

        var playerResponse = new PlayerResponse
        {
            NickName = playerEntity.NickName,
            Id = playerEntity.Id
        };

        return playerResponse;
    }

    public PlayerResponse? GetPlayerById(int playerId)
    {
        var playerEntity = _context.Players.FirstOrDefault(p => p.Id == playerId);

        if (playerEntity == null)
        {
            throw new Exception($"Not found id: {playerId}");
        }
        
        var playerResponse = new PlayerResponse
        {
            Id = playerId,
            NickName = playerEntity.NickName
        };

        return playerResponse;
    }

    public void DeletePlayerById(int playerId)
    {
        var playerEntity = _context.Players.FirstOrDefault(p => p.Id == playerId);

        if (playerEntity == null)
        {
            throw new Exception($"Not found object by id: {playerId}");
        }
        
     var delete=   _context.Players.Remove(playerEntity);
     
        _context.SaveChanges();
    }

    public PlayerResponse UpdatePlayer(int playerId, PlayerRequest playerRequest)
    {
        var player = _context.Players.FirstOrDefault(p => p.Id == playerId);

        if (player == null)
        {
            throw new Exception($"Not found object by id: {playerId}");
        }

        player.NickName = playerRequest.NickName;
        _context.Players.Update(player);
        _context.SaveChanges();
        var playerResponse = new PlayerResponse
        {
            NickName = playerRequest.NickName,
            Id = player.Id
        };
        return playerResponse;
    }
}