using Durak.Application.Interfaces;
using Durak.Contracts.Requests;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class CardService : ICardService
{
    private readonly ApplicationDbContext _context;

    public CardService(ApplicationDbContext context) => _context = context;

    public CardResponse AddCard(CardRequest cardRequest)
    {
        var cardEntity = new CardEntity()
        {
            Suit = cardRequest.Suit,
            Rank = cardRequest.Rank
        };

        _context.Cards.Add(cardEntity);
        _context.SaveChanges();

        var cardResponse = new CardResponse()
        {
            Id = cardEntity.Id,
            Rank = cardEntity.Rank,
            Suit = cardEntity.Suit
        };

        return cardResponse;
    }

    public CardResponse? GetCard(int cardId)
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