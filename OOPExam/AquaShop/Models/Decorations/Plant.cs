using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int InitialPlantComfort = 5;
        private const int InitialPlantPrice = 10;
        public Plant() 
            : base(InitialPlantComfort, InitialPlantPrice)
        {
        }
    }
}
