using Durak.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

public enum CardSuit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

public enum CardRank
{
    //Ace =1,
    Ace,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

[Route("api/[controller]/[action]")]
[ApiController]
public class CardController : Controller
{
    public List<Card> Cards = new List<Card>();

  
    DatabaseContext database = new DatabaseContext();

    [HttpPost]
    public void CreateingDb([FromBody] Card card)
    {
        var entity = new Card();
        entity.Rank = card.Rank;
        entity.Suit = card.Suit;
        database.Cards.Add(entity);
        database.SaveChanges();
    }
    
    [HttpGet]
    public OkObjectResult GetCards()
    {
        var queryable = database.Cards.ToList();
        return Ok(queryable);
    }

    [HttpDelete]
    public void DeleteCard(int id)
    {
        database.Cards.Remove(database.Cards.Find(id));
        database.SaveChanges();
    }

    [HttpPut]
    public void UpdateCard([FromBody] Card card)
    {
        database.Cards.Update(card);
        database.SaveChanges();
    }
    // public string GetCards()
    // {
    //
    //     database.Cards.Select()
    // }
    
    // public string CreateDb(Card card)
    // {

    //     Cards.Add(card); 
    //     return card.Id.;
    // }
}