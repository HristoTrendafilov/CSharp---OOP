using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public abstract class MyValidationAtribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
