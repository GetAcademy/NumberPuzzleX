﻿using System;

namespace NumberPuzzleX.Core.Domain.Model
{
    public class BaseModel
    {
        public Guid Id { get; }

        public BaseModel()
        {
            Id = Guid.NewGuid();
        }

        public BaseModel(Guid id)
        {
            Id = id;
        }
    }
}
