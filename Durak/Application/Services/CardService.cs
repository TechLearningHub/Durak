using Durak.Application.Interfaces;
using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Domain.Enums;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class CardService : ICardService
{
    private readonly ApplicationDbContext _context;

    public CardService(ApplicationDbContext context) => _context = context;

    public CardResponse AddCard()
    {
        HashSet<CardEntity> cardEntity = new HashSet<CardEntity>
        {
            new() { Rank = RankEnum.Six, Suit = SuitEnum.Club },
            new() { Rank = RankEnum.Six, Suit = SuitEnum.Diamond },
            new() { Rank = RankEnum.Six, Suit = SuitEnum.Heart },
            new() { Rank = RankEnum.Six, Suit = SuitEnum.Spade },

            new() { Rank = RankEnum.Seven, Suit = SuitEnum.Club },
            new() { Rank = RankEnum.Seven, Suit = SuitEnum.Diamond },
            new() { Rank = RankEnum.Seven, Suit = SuitEnum.Heart },
            new() { Rank = RankEnum.Seven, Suit = SuitEnum.Spade },

            new() { Rank = RankEnum.Eight, Suit = SuitEnum.Club },
            new() { Rank = RankEnum.Eight, Suit = SuitEnum.Diamond },
            new() { Rank = RankEnum.Eight, Suit = SuitEnum.Heart },
            new() { Rank = RankEnum.Eight, Suit = SuitEnum.Spade },

            new() { Rank = RankEnum.Nine, Suit = SuitEnum.Club },
            new() { Rank = RankEnum.Nine, Suit = SuitEnum.Diamond },
            new() { Rank = RankEnum.Nine, Suit = SuitEnum.Heart },
            new() { Rank = RankEnum.Nine, Suit = SuitEnum.Spade },

            new() { Rank = RankEnum.Ten, Suit = SuitEnum.Club },
            new() { Rank = RankEnum.Ten, Suit = SuitEnum.Diamond },
            new() { Rank = RankEnum.Ten, Suit = SuitEnum.Heart },
            new() { Rank = RankEnum.Ten, Suit = SuitEnum.Spade },

            new() { Rank = RankEnum.Jack, Suit = SuitEnum.Club },
            new() { Rank = RankEnum.Jack, Suit = SuitEnum.Diamond },
            new() { Rank = RankEnum.Jack, Suit = SuitEnum.Heart },
            new() { Rank = RankEnum.Jack, Suit = SuitEnum.Spade },

            new() { Rank = RankEnum.Queen, Suit = SuitEnum.Club },
            new() { Rank = RankEnum.Queen, Suit = SuitEnum.Diamond },
            new() { Rank = RankEnum.Queen, Suit = SuitEnum.Heart },
            new() { Rank = RankEnum.Queen, Suit = SuitEnum.Spade },

            new() { Rank = RankEnum.King, Suit = SuitEnum.Club },
            new() { Rank = RankEnum.King, Suit = SuitEnum.Diamond },
            new() { Rank = RankEnum.King, Suit = SuitEnum.Heart },
            new() { Rank = RankEnum.King, Suit = SuitEnum.Spade },

            new() { Rank = RankEnum.Ace, Suit = SuitEnum.Club },
            new() { Rank = RankEnum.Ace, Suit = SuitEnum.Diamond },
            new() { Rank = RankEnum.Ace, Suit = SuitEnum.Heart },
            new() { Rank = RankEnum.Ace, Suit = SuitEnum.Spade }
        };

        _context.Cards.AddRange(cardEntity);

        _context.SaveChanges();
        var c = cardEntity.FirstOrDefault(x => x.Id > 0);
        var cardResponse = new CardResponse()
        {
            Id = c.Id,
            Rank = c.Rank,
            Suit = c.Suit,
        };

        return cardResponse;
    }

    public CardResponse? GetCard(long cardId)
    {
        var cardEntity = _context.Cards.Find(cardId);
        if (cardEntity == null)
        {
            return null;
        }

        var cardResponse = new CardResponse()
        {
            Id = cardEntity.Id,
            Suit = cardEntity.Suit,
            Rank = cardEntity.Rank
        };

        return cardResponse;
    }

    public CardResponse UpdateCard(int cardId, CardRequest cardRequest)
    {
        var cardEntity = _context.Cards.Find(cardId);
        if (cardEntity == null)
        {
            throw new Exception($"not find card by id: {cardId}");
        }

        cardEntity.Id = cardId;
        cardEntity.Rank = cardRequest.Rank;
        cardEntity.Suit = cardRequest.Suit;
        _context.SaveChanges();

        var cardResponse = new CardResponse()
        {
            Id = cardId,
            Suit = cardRequest.Suit,
            Rank = cardRequest.Rank
        };

        return cardResponse;
    }

    public CardResponse DeleteCard(int cardId)
    {
        var cardEntity = _context.Cards.Find(cardId);
        if (cardEntity == null)
        {
            throw new Exception($"not find card by id: {cardId}");
        }

        _context.Cards.Remove(cardEntity);
        _context.SaveChanges();

        var cardResponse = new CardResponse()
        {
            Id = cardId,
            Suit = cardEntity.Suit,
            Rank = cardEntity.Rank
        };

        return cardResponse;
    }
}