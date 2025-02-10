using System.Runtime.InteropServices.JavaScript;
using Durak.Application.Interfaces;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public  class GameService(ApplicationDbContext context) : IGameService
{
    private Random _random = new Random();
    
    public  PlayerCardsResponse Withdraw(int playerId,int cardCount)
    { 
        HandEntity handEntity = new HandEntity();   

        if (context.Players.Any(p => p.Id == playerId))
        {
            for (int i = 1; i <= cardCount; i++)
            {
                var randomCardNumber = _random.Next(36);
                handEntity.CardIds.Add(randomCardNumber);
            }
            context.Hands.Add(handEntity);
            context.SaveChanges();
        }
        else
        {
            throw new Exception("Player not found");
        }

        var convert = new PlayerCardsResponse()
        {
            Id = playerId,
            CardIds = handEntity.CardIds,
        };
        return convert;
    }
}