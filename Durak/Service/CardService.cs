using Durak.Contracts;
using Durak.Domain.Entities;
using Durak.Infrastructure;
using Durak.Interface;

namespace Durak.Service;

public class CardService : ICardEntity
{
    private readonly ApplicationDbContext _context;

    public CardService(ApplicationDbContext context) => _context = context;

    public CardEntity CreateCardEntity(CardRequest cardRequest)
    {
        CardEntity cardEntity = new CardEntity();
        // cardRequest.Rank = cardEntity.Rank;
        // cardRequest.Suit = cardEntity.Suit;
        cardEntity.Suit = cardRequest.Suit;
        cardEntity.Rank = cardRequest.Rank;
        _context.Cards.Add(cardEntity);
        _context.SaveChanges();
        return cardEntity;
    }

    public CardEntity GetCardEntity(int id)
    {
        return _context.Cards.FirstOrDefault(p => p.Id == id)!;
    }

    public CardEntity UpdateCardEntity(int id, CardRequest cardRequest)
    {
        CardEntity cardEntity = _context.Cards.FirstOrDefault(p => p.Id == id)!;
        cardEntity.Rank = cardRequest.Rank;
        cardEntity.Suit = cardRequest.Suit;
        _context.Cards.Update(cardEntity);
        _context.SaveChanges();
        return cardEntity;
    }

    public CardEntity DeleteCardEntity(int id)
    {
        CardEntity cardEntity = _context.Cards.FirstOrDefault(p => p.Id == id)!;
        _context.Cards.Remove(cardEntity);
        _context.SaveChanges();
        return cardEntity;
    }
}