using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Car
    {
        private const double SummerAdditionalConsumption = 1.6;
        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.LitersPerKm = litersPerKm;
            this.TankCapacity = tankCapacity;
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
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.TankCapacity < this.FuelQuantity + fuel)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuel * 0.95;
            }
        }
    }
}
