//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {

        [Test]
        public void ConstructorShouldInitiazlizeCorrectly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
        }
        [Test]
        public void ModelShouldThrowArgumentExceptionWhenNameIsNull()
        {
            string make = "VW";
            string model = null;
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() => 
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void MakeShouldThrowArgumentExceptionWhenNameIsNull()
        {
            string make = null;
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenNegativeNumber()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = -1;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenItsZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 0;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelCapacityShouldThrowArgumentExceptionWhenItsZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 0;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelCapacityShouldThrowArgumentExceptionWhenItsNegativeNumber()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = -1;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
    
        [Test]
        public void ShouldRefuelNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            
            car.Refuel(10);
            
            int expectedFuelAmount = 10;
            double actualFuelAmount = car.FuelAmount;
           
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        [Test]
        public void ShouldRefuelUntillTheTotalFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(150);

            int expectedFuelAmount = 100;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void RefuelShouldThrowArgumentExceptionWhenInputAmountIsBelowZero
            (double inputAmount)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(-100));
        }
        [Test]
        public void ShouldDriveNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(20);

            car.Drive(20);

            double expectedFuelAmount = 19.6;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        [Test]
        public void DriveShouldThrowInvalidOperationExceptionWhenFuelAmountIsNotEnough()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<InvalidOperationException>(() => car.Drive(20));
        }
    }
}