using Durak.Contracts;
using Durak.Domain.Entities;
using Durak.Infrastructure;
using Durak.Interface;

namespace Durak.Service;

public class PlayerService : IPlayer
{
    private readonly ApplicationDbContext _context;
    public PlayerService(ApplicationDbContext context) => _context = context;

    public PlayerEntity CreatePlayer(PlayerRequest playerRequest)
    {
        PlayerEntity playerEntity = new PlayerEntity();
        playerEntity.NickName = playerRequest.NikName;
        _context.Players.Add(playerEntity);
        _context.SaveChanges();
        return playerEntity;
    }

    public PlayerEntity GetPlayer(int playerId)
    {
        return _context.Players.FirstOrDefault(p => p.Id == playerId)!;
    }

    public PlayerEntity UpdatePlayer(int playerId, PlayerRequest playerRequest)
    {
        PlayerEntity playerEntity = _context.Players.FirstOrDefault(p => p.Id == playerId)!;
        playerEntity.NickName = playerRequest.NikName;
        _context.Players.Update(playerEntity);
        _context.SaveChanges();
        return playerEntity;
    }

    public PlayerEntity DeletePlayer(int playerId)
    {
        PlayerEntity playerEntity = _context.Players.FirstOrDefault(p => p.Id == playerId)!;
        _context.Players.Remove(playerEntity);
        _context.SaveChanges();
        return playerEntity;
    }
}