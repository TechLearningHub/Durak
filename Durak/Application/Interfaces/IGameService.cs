using Durak.Contracts.Responses;
using Durak.Domain.Entities;

namespace Durak.Application.Interfaces;

public interface IGameService
{
    public List<CardEntity>? Withdraw(long playerId, long deskId);
}