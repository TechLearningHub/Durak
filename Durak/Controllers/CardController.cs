using Durak.Application.Interfaces;
using Durak.Contracts.Request;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController: ControllerBase
{
    private readonly ICardService _cardService;

 public CardController(ICardService cardService)
 {
     _cardService= cardService;
 }
    [HttpPost]
    public void Post(CardRequest card)
    {
       _cardService.AddCard(card);
    }
    
    
}