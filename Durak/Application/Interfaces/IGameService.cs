using Durak.Contracts.Responses;
using Durak.Domain.Entities;

namespace Durak.Application.Interfaces;

public interface IGameService
{
    public HashSet<CardEntity> Withdraw(long playerId, long deskId);
}