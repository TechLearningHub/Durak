using Durak.Application.Interfaces;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class GameService(ApplicationDbContext context) : IGameService
{
    private static List<CardEntity> _cardList = new();

    private readonly Random _random = new();

    public List<CardEntity> Withdraw(long playerId, long deskId)
    {
        if (_cardList.Count <= 0)
        {
            _cardList = context.Cards.ToList();
        }

        var handEntity = new HandEntity();
        var playerEntity = context.Players.FirstOrDefault(x => x.Id == playerId);

        if (playerEntity == null)
        {
            throw new Exception("not found");
        }

        if (_cardList.Count >= 6)
        {
            for (int i = 1; i <= 6; i++)
            {
                var randomCardNumber = _random.Next(1, _cardList.Count);
                if (_cardList.Count == 1)
                {
                    handEntity.CardIds.Add(_cardList[0].Id);
                    _cardList.RemoveAt(0);
                    break;
                }

                var findIndex = _cardList[randomCardNumber];
                handEntity.CardIds.Add(findIndex.Id);
                _cardList.RemoveAt(randomCardNumber);
            }

            handEntity.Player = playerEntity;
            handEntity.DeskId = deskId;
            context.Hands.Add(handEntity);
            context.SaveChanges();
        }

        return _cardList;
    }
}