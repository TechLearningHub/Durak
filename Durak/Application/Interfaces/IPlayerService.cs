using Durak.Contracts.Request;
using Durak.Contracts.Responses;

namespace Durak.Application.Interfaces;

 public interface IPlayerService
{
    public PlayerResponse AddPlayer(PlayerRequest player);
    public PlayerResponse? GetPlayerById(int playerId);
    public PlayerResponse DeletePlayerById(int playerId);
    public PlayerResponse? UpdatePlayer(int playerId, PlayerRequest playerRequest);
}