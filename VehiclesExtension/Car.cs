using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Car
    {
        private const double SummerAdditionalConsumption = 0.9;
        private double fuelQuantity;

        public Car(double fuelQuantity, double litersPerKm, double tankCapacity)
        {

            FuelQuantity = fuelQuantity;
            LitersPerKm = litersPerKm;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            
            protected set
            {
                if (value < 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                }
                if (this.fuelQuantity > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double LitersPerKm { get; protected set; }
        public double TankCapacity { get; protected set; }

        public virtual void Drive(double distance)
        {
            if (this.FuelQuantity > distance * (this.LitersPerKm + SummerAdditionalConsumption))
            {
                this.FuelQuantity -= distance * (this.LitersPerKm + SummerAdditionalConsumption);
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.TankCapacity < this.fuelQuantity + fuel)
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
