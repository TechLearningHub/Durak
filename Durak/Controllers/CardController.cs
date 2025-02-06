using Durak.Contracts;
using Durak.Domain.Entities;
using Durak.Infrastructure;
using Durak.Interface;
using Durak.Service;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardController : ControllerBase
{
    private readonly ICardEntity _cardService;

    public CardController(ICardEntity cardService)
    {
        _cardService = cardService;
    }

    [HttpPost]
    public void Post(CardRequest cardRequest)
    {
        _cardService.CreateCardEntity(cardRequest);
    }
}