﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLSerializer
{
    public interface IValidator<T>
    {
        bool Validate(T element);
    }
}
