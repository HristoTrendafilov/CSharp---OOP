using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car
    {
        private const double SummerAdditionalConsumption = 0.9;
        private double litersPerKm;

        public Car(double fuelQuantity, double litersPerKm)
        {
            FuelQuantity = fuelQuantity;
            LitersPerKm = litersPerKm;
        }

        public double FuelQuantity { get; protected set; }
        public double LitersPerKm { get; protected set; }

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
            this.FuelQuantity += fuel;
        }
    }
}
