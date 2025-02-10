using Durak.Contracts.Request;
using Durak.Contracts.Responses;

namespace Durak.Application.Interfaces;

public interface IHandService
{
    public HandResponse AddHand(HandRequest request);
    public HandResponse? GetHandById(int handId);
    public HandResponse DeleteHandById(int handId);
    public HandResponse? UpdateHand(int handId, HandRequest handRequest);
}