using Durak.Application.Interfaces;
using Durak.Contracts.Requests;
using Durak.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Durak.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DeskController : ControllerBase
{
    private readonly IDeskService _deskService;

    public DeskController(IDeskService deskService)
    {
        _deskService = deskService;
    }

    [HttpPost]
    public void AddDesk(DeskRequest deskRequest)
    {
        _deskService.AddDesk(deskRequest);
    }

    [HttpGet]
    public DeskResponse? GetDeskById(int deskId)
    {
        return _deskService.GetDeskById(deskId);
    }

    [HttpDelete]
    public void DeleteDesk(int deskId)
    {
        _deskService.DeleteDeskById(deskId);
    }

    [HttpPut]
    public DeskResponse UpdateDesk(DeskRequest deskRequest, int deskId)
    {
        return _deskService.UpdateDesk(deskId, deskRequest);
    }
}