using Durak.Application.Interfaces;
using Durak.Contracts.Requests;
using Durak.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HandController : ControllerBase
{
    private readonly IHandService _handService;

    public HandController(IHandService handService)
    {
        _handService = handService;
    }

    [HttpPost]
    public void AddHand(HandRequest handRequest)
    {
        _handService.AddHand(handRequest);
    }

    [HttpGet]
    public HandResponse? GetHandById(int handId)
    {
        return _handService.GetHandById(handId);
    }

    [HttpDelete]
    public void DeletePlayer(int handId)
    {
        _handService.DeleteHandById(handId);
    }

    [HttpPut]
    public HandResponse UpdateHand(HandRequest handRequest, int handId)
    {
        return _handService.UpdateHand(handId, handRequest);
    }
}