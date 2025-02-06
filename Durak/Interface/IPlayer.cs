using Durak.Contracts;
using Durak.Domain.Entities;

namespace Durak.Interface;

public interface IPlayer
{
    public PlayerEntity CreatePlayer(PlayerRequest playerRequest);
    public PlayerEntity? GetPlayer(int playerId);
    public PlayerEntity? UpdatePlayer(int playerId, PlayerRequest playerRequest);
    public PlayerEntity DeletePlayer(int playerId);
}