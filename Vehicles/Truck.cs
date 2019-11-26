using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Car
    {
        private const double SummerAdditionalConsumption = 1.6;
        public Truck(double fuelQuantity, double litersPerKm) 
            : base(fuelQuantity, litersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.LitersPerKm = litersPerKm;
        }
        public override void Drive(double distance)
        {
            if (this.FuelQuantity > distance * (this.LitersPerKm  + SummerAdditionalConsumption))
            {
                this.FuelQuantity -= distance * (this.LitersPerKm + SummerAdditionalConsumption);
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }
        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * 0.95;
        }
    }
}
