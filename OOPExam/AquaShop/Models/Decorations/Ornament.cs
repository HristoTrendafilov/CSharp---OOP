using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int InitialOrnamentComfort = 1;
        private const int InitialOrnamentPrice = 5;
        public Ornament() 
            : base(InitialOrnamentComfort, InitialOrnamentPrice)
        {
        }
    }
}
