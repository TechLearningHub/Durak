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

    [HttpPost]
    public IActionResult AddCard(Card card)
    {
        Cards.Add(card);
        return Ok(card);
    }
    // public string CreateDb(Card card)
    // {

    //     Cards.Add(card); 
    //     return card.Id.;
    // }
}