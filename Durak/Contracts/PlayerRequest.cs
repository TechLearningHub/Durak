﻿using Durak.Domain.Entities;

namespace Durak.Contracts;

public class PlayerRequest
{
    public string NickName { get; set; } = string.Empty;
}