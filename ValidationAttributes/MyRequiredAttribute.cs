using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAtribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}
