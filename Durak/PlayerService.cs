using Durak.Contracts;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak;

public class PlayerService : IPlayerService
{
    private readonly ApplicationDbContext _context;

    public PlayerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public PlayerEntity AddPlayer(PlayerRequest playerRequest)
    {
        var player = new PlayerEntity
        {
            NickName = playerRequest.NickName
        };
        _context.Players.Add(player);
        _context.SaveChanges();
        return player;
    }

    public PlayerEntity? GetPlayerById(int playerId)
    {
        return _context.Players.FirstOrDefault(p => p.Id == playerId);
    }

    public PlayerEntity DeletePlayerById(int playerId)
    {
        var player = _context.Players.FirstOrDefault(p => p.Id == playerId);
        
        if (player == null)
        {
            throw new Exception($"Not found object by id: {playerId}");
        }

        _context.Players.Remove(player);
        _context.SaveChanges();
        return player;
    }

    public PlayerEntity UpdatePlayer(int id, PlayerRequest playerRequest)
    {
        var player = _context.Players.FirstOrDefault(p => p.Id == id);
        
        if (player == null)
        {
            throw new Exception($"Not found object by id: {id}");
        }
        
        player.NickName = playerRequest.NickName;
        _context.Players.Update(player);
        _context.SaveChanges();
        return player;
    }
}