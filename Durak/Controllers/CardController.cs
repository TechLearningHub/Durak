using Durak.Contracts;
using Durak.Domain.Entities;
using Durak.Infrastructure;
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
    // fix return type 
    public void Post(CardRequest card)
    {
       _cardService.AddCard(card);
    }
    
    
}