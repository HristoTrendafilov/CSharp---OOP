using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface IFerrari
    {
         string Name { get; }
         string UseBrakes();
         string UseGas();       
    }
}
