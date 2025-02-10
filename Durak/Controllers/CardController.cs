using Durak.Application.Interfaces;
using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ICard _card;

    public CardController(ICard card)
    {
        _card = card;
    }

    [HttpPost]
    public void Post(CardRequest card)
    {
        _card.AddCard(card);
    }

    [HttpGet]
    public CardResponse GetCard(int cardId)
    {
        return _card.GetCard(cardId);
    }

    [HttpPut]
    public CardResponse CardUpdate(int cardId, CardRequest cardRequest)
    {
        return _card.UpdateCard(cardId, cardRequest);
    }

    [HttpDelete]
    public void DeleteCard(int cardId)
    {
        _card.DeleteCard(cardId);
    }
}