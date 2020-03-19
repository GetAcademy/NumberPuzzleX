using System;
using System.Collections.Generic;
using System.Text;

namespace _40_NumberPuzzleX.Core.Domain.Model
{
    public class BaseModel
    {
        public Guid Id { get; }

        public BaseModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
