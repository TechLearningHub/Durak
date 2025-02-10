using Durak.Application.Interfaces;
using Durak.Contracts.Requests;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class PlayerService(ApplicationDbContext context) : IPlayerService
{
    public PlayerResponse AddPlayer(PlayerRequest playerRequest)
    {
        var player = new PlayerEntity
        {
            NickName = playerRequest.NickName
        };

        var playerEntity = context.Players.Add(player).Entity;
        context.SaveChanges();

        var playerResponse = new PlayerResponse
        {
            NickName = playerEntity.NickName,
            Id = playerEntity.Id
        };

        return playerResponse;
    }

    public PlayerResponse? GetPlayerById(int playerId)
    {
        var playerEntity = context.Players.Find(playerId);

        if (playerEntity == null)
        {
            return null;
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
        var playerEntity = context.Players.Find(playerId);

        if (playerEntity == null)
        {
            throw new Exception($"Not found object by id: {playerId}");
        }

        context.Players.Remove(playerEntity);

        context.SaveChanges();
    }

    public PlayerResponse UpdatePlayer(int playerId, PlayerRequest playerRequest)
    {
        var player = context.Players.Find(playerId);

        if (player == null)
        {
            throw new Exception($"Not found object by id: {playerId}");
        }

        player.NickName = playerRequest.NickName;
        context.Players.Update(player);
        context.SaveChanges();
        var playerResponse = new PlayerResponse
        {
            NickName = playerRequest.NickName,
            Id = player.Id
        };

        return playerResponse;
    }
}