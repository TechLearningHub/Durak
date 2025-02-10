using Durak.Application.Interfaces;
using Durak.Contracts.Requests;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class HandService(ApplicationDbContext context) : IHandService
{
    public HandResponse AddHand(HandRequest request)
    {
        var hand = new HandEntity
        {
            PlayerId = request.PlayerId,
        };

        context.Hands.Add(hand);
        context.SaveChanges();

        var handResponse = new HandResponse
        {
            PlayerId = request.PlayerId,
        };

        return handResponse;
    }

    public HandResponse? GetHandById(int handId)
    {
        var handEntity = context.Hands.Find(handId);
        if (handEntity == null)
        {
            return null;
        }

        var handResponse = new HandResponse
        {
            Id = handId,
            DeskId = handEntity.DeskId,
            PlayerId = handEntity.PlayerId
        };

        return handResponse;
    }

    public void DeleteHandById(int handId)
    {
        var handEntity = context.Hands.Find(handId);

        if (handEntity == null)
        {
            throw new Exception($"Not found object by id: {handId}");
        }

        context.Hands.Remove(handEntity);
        context.SaveChanges();

        var handResponse = new HandResponse()
        {
            Id = handId,
            DeskId = handEntity.DeskId,
            PlayerId = handEntity.PlayerId
        };
    }

    public HandResponse UpdateHand(int handId, HandRequest handRequest)
    {
        var handEntity = context.Hands.Find(handId);

        if (handEntity == null)
        {
            throw new Exception($"Not found object by id: {handId}");
        }

        handEntity.DeskId = handRequest.DeskId;
        context.Hands.Update(handEntity);
        context.SaveChanges();
        var handResponse = new HandResponse()
        {
            Id = handId,
            DeskId = handEntity.DeskId,
            PlayerId = handEntity.PlayerId
        };
        return handResponse;
    }
}