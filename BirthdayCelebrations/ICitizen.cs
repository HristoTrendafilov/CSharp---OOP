using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface ICitizen : IRobot
    {
         int Age { get; }
         string Birthday { get; }
    }
}
