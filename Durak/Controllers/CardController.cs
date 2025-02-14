using Durak.Application.Interfaces;
using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpPost]
    public CardResponse Post()
    {
        return _cardService.AddCard();
    }

    [HttpGet]
    public CardResponse GetCard(long cardId)
    {
        return _cardService.GetCard(cardId);
    }

    [HttpPut]
    public CardResponse CardUpdate(int cardId, CardRequest cardRequest)
    {
        return _cardService.UpdateCard(cardId, cardRequest);
    }

    [HttpDelete]
    public CardResponse DeleteCard(int cardId)
    {
        return _cardService.DeleteCard(cardId);
    }
}