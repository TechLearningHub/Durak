using Durak.Application.Interfaces;
using Durak.Contracts.Request;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class HandService(ApplicationDbContext context) : IHandService
{
    private readonly ApplicationDbContext _context = context;

    public HandResponse AddHand(HandRequest request)
    {
        var hand = new HandEntity
        {
            PlayerId = request.PlayerId,
        };

        var handEntity = _context.Hands.Add(hand).Entity;
        _context.SaveChanges();

        var handResponse = new HandResponse
        {
            PlayerId = request.PlayerId,
        };

        return handResponse;
    }

    public HandResponse? GetHandById(int handId)
    {
        var handEntity = _context.Hands.FirstOrDefault(x => x.Id == handId);
        if (handEntity == null)
        {
            throw new Exception($"Not found id: {handId}");
        }

        var handResponse = new HandResponse
        {
            Id = handId,
            DeskId = handEntity.DeskId,
            PlayerId = handEntity.PlayerId
        };
        
        return handResponse;
    }

    public HandResponse DeleteHandById(int handId)
    {
        var handEntity = _context.Hands.FirstOrDefault(p => p.Id == handId);

        if (handEntity == null)
        {
            throw new Exception($"Not found object by id: {handId}");
        }

        _context.Hands.Remove(handEntity);
        _context.SaveChanges();

        var handResponse = new HandResponse()
        {
            Id = handId,
            DeskId = handEntity.DeskId,
            PlayerId = handEntity.PlayerId
        };

        return handResponse;
    }

    public HandResponse UpdateHand(int handId, HandRequest handRequest)
    {
        var handEntity = _context.Hands.FirstOrDefault(p => p.Id == handId);

        if (handEntity == null)
        {
            throw new Exception($"Not found object by id: {handId}");
        }

        handEntity.DeskId = handRequest.DeskId;
        _context.Hands.Update(handEntity);
        _context.SaveChanges();
        var handResponse = new HandResponse()
        {
            Id = handId,
            DeskId = handEntity.DeskId,
            PlayerId = handEntity.PlayerId
        };
        return handResponse;
    }
}