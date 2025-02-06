using Durak.Contracts;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak;

public class CardService : ICardService
{
    private readonly ApplicationDbContext _context;

    public CardService(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public CardEntity AddCard(CardRequest cardRequest)
    {
        var cardEntity = new CardEntity
        {
            Rank = cardRequest.Rank,
            Suit = cardRequest.Suit
        };
        _context.Cards.Add(cardEntity);
        _context.SaveChanges();
        return cardEntity;
    }
}