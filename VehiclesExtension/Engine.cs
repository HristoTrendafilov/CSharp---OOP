using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Engine
    {
        public void Run()
        {
            var carInfo = Console.ReadLine().Split();
            var carFuelQuantity = double.Parse(carInfo[1]);
            var carLitersPerKm = double.Parse(carInfo[2]);
            var carTankCapacity = double.Parse(carInfo[3]);

            var car = new Car(carFuelQuantity, carLitersPerKm,carTankCapacity);

            var truckInfo = Console.ReadLine().Split();
            var truckFuelQuantity = double.Parse(truckInfo[1]);
            var truckLitersPerKm = double.Parse(truckInfo[2]);
            var truckTankCapacity = double.Parse(truckInfo[3]);

            var truck = new Truck(truckFuelQuantity, truckLitersPerKm,truckTankCapacity);

            var busInfo = Console.ReadLine().Split();
            var busFuelQuantity = double.Parse(busInfo[1]);
            var busLitersPerKm = double.Parse(busInfo[2]);
            var busTankCapacity = double.Parse(busInfo[3]);

            var bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);

            var counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }
                else if(command[0]=="Drive" && command[1] == "Car")
                {
                    var kilometersToDrive = double.Parse(command[2]);
                    car.Drive(kilometersToDrive);
                }
                else if(command[0]=="Refuel" && command[1] == "Car")
                {
                    var fuel = double.Parse(command[2]);
                    car.Refuel(fuel);
                }
                else if (command[0] == "Drive" && command[1] == "Truck")
                {
                    var kilometersToDrive = double.Parse(command[2]);
                    truck.Drive(kilometersToDrive);
                }
                else if (command[0] == "Refuel" && command[1] == "Truck")
                {
                    var fuel = double.Parse(command[2]);
                    truck.Refuel(fuel);
                }
                else if (command[0] == "Drive" && command[1] == "Bus")
                {
                    var kilometersToDrive = double.Parse(command[2]);
                    bus.DriveWithPeople(kilometersToDrive);
                }
                else if (command[0] == "DriveEmpty") 
                {
                    var kilometersToDrive = double.Parse(command[2]);
                    bus.Drive(kilometersToDrive);
                }
                else if (command[0] == "Refuel" && command[1] == "Bus")
                {
                    var fuel = double.Parse(command[2]);
                    bus.Refuel(fuel);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
