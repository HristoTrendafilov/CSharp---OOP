using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Car
    {
        private const double FuelConsumptionWithPeople = 1.4;
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.LitersPerKm = litersPerKm;
            this.TankCapacity = tankCapacity;
        }
        public void DriveWithPeople(double distance)
        {
            if (this.FuelQuantity > distance * (this.LitersPerKm + FuelConsumptionWithPeople))
            {
                this.FuelQuantity -= distance * (this.LitersPerKm + FuelConsumptionWithPeople);
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        public override void Drive(double distance)
        {
            if (this.FuelQuantity > distance * this.LitersPerKm)
            {
                this.FuelQuantity -= distance * this.LitersPerKm;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.TankCapacity < this.TankCapacity + fuel)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuel;
            }
        }
    }
}
