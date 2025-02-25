﻿using Durak.Contracts.Requests;
using Durak.Contracts.Responses;

namespace Durak.Application.Interfaces;

public interface IHandService
{
    public HandResponse AddHand(HandRequest request);
    public HandResponse? GetHandById(int handId);
    public void DeleteHandById(int handId);
    public HandResponse UpdateHand(int handId, HandRequest handRequest);
}