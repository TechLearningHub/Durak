using Durak.Contracts.Request;
using Durak.Domain.Entities;

namespace Durak.Application.Interfaces;

public interface ICardService
{
    public CardEntity AddCard(CardRequest cardRequest);
}