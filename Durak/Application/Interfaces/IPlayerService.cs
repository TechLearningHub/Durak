using Durak.Contracts.Requests;
using Durak.Contracts.Responses;

namespace Durak.Application.Interfaces;

 public interface IPlayerService
{
    public PlayerResponse AddPlayer(PlayerRequest player);
    public PlayerResponse? GetPlayerById(int playerId);
    public void DeletePlayerById(int playerId);
    public PlayerResponse UpdatePlayer(int playerId, PlayerRequest playerRequest);
}