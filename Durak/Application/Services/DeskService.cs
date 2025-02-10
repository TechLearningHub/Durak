using Durak.Application.Interfaces;
using Durak.Contracts.Requests;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class DeskService(ApplicationDbContext context) : IDeskService
{
    public DeskResponse AddDesk(DeskRequest request)
    {
        var desk = new DeskEntity
        {
            Winner = request.Winner,
            CardId = request.CardId
        };

        var handEntity = context.Desks.Add(desk).Entity;
        context.SaveChanges();

        var deskResponse = new DeskResponse()
        {
            CardId = request.CardId,
            Winner = request.Winner
        };

        return deskResponse;
    }

    public DeskResponse? GetDeskById(int deskId)
    {
        var deskEntity = context.Desks.Find(deskId);
        if (deskEntity == null)
        {
            return null;
        }

        var deskResponse = new DeskResponse()
        {
            Id = deskId,
            CardId = deskEntity.CardId,
            Winner = deskEntity.Winner
        };

        return deskResponse;
    }

    public void DeleteDeskById(int deskId)
    {
        var deskEntity = context.Desks.Find(deskId);

        if (deskEntity == null)
        {
            throw new Exception($"Not found object by id: {deskId}");
        }

        context.Desks.Remove(deskEntity);
        context.SaveChanges();

        var deskResponse = new DeskResponse()
        {
            Id = deskId,
            Winner = deskEntity.Winner,
            CardId = deskEntity.CardId
        };
    }

    public DeskResponse UpdateDesk(int deskId, DeskRequest deskRequest)
    {
        var deskEntity = context.Desks.Find(deskId);

        if (deskEntity == null)
        {
            throw new Exception($"Not found object by id: {deskId}");
        }

        deskEntity.CardId = deskRequest.CardId;
        deskEntity.Winner = deskRequest.Winner;
        context.Desks.Update(deskEntity);
        context.SaveChanges();

        var deskResponse = new DeskResponse()
        {
            Id = deskId,
            Winner = deskEntity.Winner,
            CardId = deskEntity.CardId
        };

        return deskResponse;
    }
}