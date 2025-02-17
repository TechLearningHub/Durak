using Durak.Application.Interfaces;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class GameServiceCopy(ApplicationDbContext context) : IGameService
{
    private static List<CardEntity> _deck = [];

    private readonly Random _random = new();

    public HashSet<CardEntity> Withdraw(long playerId, long deskId)
    {
        if (_deck.Count <= 0)
        {
            _deck = context.Cards.ToList();
        }

        var playerEntity = context.Players.FirstOrDefault(x => x.Id == playerId)
                           ?? throw new Exception("Not found player");

        var handEntity = new HandEntity();

        if (_deck.Count <= 6)
        {
            handEntity.CardIds.AddRange(_deck.Select(e => e.Id).ToList());
            handEntity.Player = playerEntity;
            handEntity.DeskId = deskId;
            context.Hands.Add(handEntity);
            context.SaveChanges();
            _deck.RemoveAll(e => e.Id > 0);
            return [];
        }

        for (var i = 1; i <= 6; i++)
        {
            AddRandomCardToPlayerHand(handEntity);
        }

        handEntity.Player = playerEntity;
        handEntity.DeskId = deskId;
        context.Hands.Add(handEntity);
        context.SaveChanges();

        return _deck.ToHashSet();
    }

    private void AddRandomCardToPlayerHand(HandEntity handEntity)
    {
        var cardIndex = _random.Next(1, _deck.Count);
        var card = _deck[cardIndex];
        handEntity.CardIds.Add(card.Id);
        _deck.RemoveAt(cardIndex);
    }
}