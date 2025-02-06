using Durak.Contracts;
using Durak.Domain.Entities;
using Durak.Infrastructure;
using Durak.Interface;

namespace Durak.Service;

public class CardService : ICardEntity
{
    private readonly ApplicationDbContext _context;

    public CardService(ApplicationDbContext context)
    {
        _context = context;
    }

    public CardEntity CreateCardEntity(CardRequest cardRequest)
    {
        CardEntity cardEntity = new CardEntity();
        // cardRequest.Rank = cardEntity.Rank;
        // cardRequest.Suit = cardEntity.Suit;
        cardEntity.Suit=cardRequest.Suit;
        cardEntity.Rank = cardRequest.Rank;
        _context.Cards.Add(cardEntity);
        _context.SaveChanges();
        return cardEntity;
    }

    public CardEntity GetCardEntity()
    {
        throw new NotImplementedException();
    }

    public CardEntity UpdateCardEntity()
    {
        throw new NotImplementedException();
    }

    public CardEntity DeleteCardEntity()
    {
        throw new NotImplementedException();
    }
}