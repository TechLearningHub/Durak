using Durak.Domain.Entities;
namespace Durak.Contracts;

 public interface IPlayerService
{
    public PlayerEntity AddPlayer(PlayerRequest player);
    public PlayerEntity? GetPlayerById(int playerId);
    public PlayerEntity DeletePlayerById(int playerId);
    public PlayerEntity? UpdatePlayer(int id, PlayerRequest playerRequest);
}