﻿using Durak.Domain.Entities;
using Durak.Domain.Enums;

namespace Durak.Contracts.Request;

public class MoveRequest
{
    public List<long> MovedCardIds { get; set; } = [];
    public int MoveId { get; set; }
    public ActionTypeEnum ActionType { get; set; }
    public PlayerEntity Player { get; set; } = new();
    public long PlayerId { get; set; }
    public bool IsBeaten { get; set; }
    public bool IsTaken { get; set; }
    public List<long> BeatenCardIds { get; set; } = [];
}