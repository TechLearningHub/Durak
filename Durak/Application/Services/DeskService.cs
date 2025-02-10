using Durak.Application.Interfaces;
using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class DeskService(ApplicationDbContext context) : IDeskService
{
    private readonly ApplicationDbContext _context = context;

    public DeskResponse AddDesk(DeskRequest request)
    {
        var desk = new DeskEntity
        {
            Winner = request.Winner,
            CardId = request.CardId
        };

        var handEntity = _context.Desks.Add(desk).Entity;
        _context.SaveChanges();

        var deskResponse = new DeskResponse()
        {
            CardId = request.CardId,
            Winner = request.Winner
        };

        return deskResponse;
    }

    public DeskResponse? GetDeskById(int deskId)
    {
        var deskEntity = _context.Desks.FirstOrDefault(x => x.Id == deskId);
        if (deskEntity == null)
        {
            throw new Exception($"Not found id: {deskId}");
        }

        var deskResponse = new DeskResponse()
        {
            Id = deskId,
            CardId = deskEntity.CardId,
            Winner = deskEntity.Winner
        };

        return deskResponse;
    }

    public DeskResponse DeleteDeskById(int deskId)
    {
        var deskEntity = _context.Desks.FirstOrDefault(p => p.Id == deskId);

        if (deskEntity == null)
        {
            throw new Exception($"Not found object by id: {deskId}");
        }

        _context.Desks.Remove(deskEntity);
        _context.SaveChanges();

        var deskResponse = new DeskResponse()
        {
            Id = deskId,
            Winner = deskEntity.Winner,
            CardId = deskEntity.CardId
           
        };

        return deskResponse;
    }

    public DeskResponse? UpdateDesk(int deskId, DeskRequest deskRequest)
    {
        var deskEntity = _context.Desks.FirstOrDefault(p => p.Id == deskId);

        if (deskEntity == null)
        {
            throw new Exception($"Not found object by id: {deskId}");
        }

        deskEntity.CardId = deskRequest.CardId;
        deskEntity.Winner = deskRequest.Winner;
        _context.Desks.Update(deskEntity);
        _context.SaveChanges();
        
        var deskResponse = new DeskResponse()
        { Id = deskId,
           Winner = deskEntity.Winner,
           CardId = deskEntity.CardId
        };
        
        return deskResponse;
    }
}