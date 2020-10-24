namespace Aquariums.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [Test]
        public void FishProppertiesShouldBeCorrect()
        {
            var name = "Pesho";

            var fish = new Fish(name);

            Assert.AreEqual("Pesho", fish.Name);
            Assert.AreEqual(true, fish.Available);
        }
        [Test]
        public void AquariumConstructorShouldWorkPropperly()
        {
            var name = "Ivan";
            var capacity = 10;
            var list = new List<Fish>();

            var aquarium = new Aquarium("Ivan", 10);

            Assert.AreEqual(name, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }
        [Test]
        public void NameShouldThrowArgumentNullExceptionIfGivenNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 10));
        }
        [Test]
        public void CapacityShouldThrowArgumentExceptionIfValueIsNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Pesho", -2));
        }
        [Test]
        public void CountPropertyShouldReturnCorrectNumber()
        {
            var fish = new Fish("Atanas");
            var fish1 = new Fish("Ivan");
            var fish2 = new Fish("Pesho");

            var aquarium = new Aquarium("Pff", 12);
            aquarium.Add(fish);
            aquarium.Add(fish1);
            aquarium.Add(fish2);

            var expected = 3;
            var actual = aquarium.Count;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfCapacityIsFull()
        {
            var fish = new Fish("Atanas");
            var fish1 = new Fish("Ivan");

            var aquarium = new Aquarium("Pff", 2);
            aquarium.Add(fish);
            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Misho")));
        }
        [Test]
        public void RemoveFishShouldThrowInvalidOperationExceptionIfGivenNull()
        {
            Assert.Throws<InvalidOperationException>(() => new Aquarium("Pesho", 2).RemoveFish(null));
        }
        [Test]
        public void SellFishShouldThrowInvalidOperationExceptionIfGivenNull()
        {
            Assert.Throws<InvalidOperationException>(() => new Aquarium("Pesho", 2).SellFish(null));
        }
        [Test]
        public void ReportMethodShouldWorkPropperly()
        {
            var fish = new Fish("Atanas");
            var fish1 = new Fish("Ivan");

            var aquarium = new Aquarium("Pff", 2);
            aquarium.Add(fish);
            aquarium.Add(fish1);

            var expected = "Fish available at Pff: Atanas, Ivan";
            var actual = aquarium.Report();

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SellFishMethodShouldWorkPropperly()
        {
            var fish1 = new Fish("Ivan");

            var aquarium = new Aquarium("Pff", 2);
            aquarium.Add(fish1);

            var expected = fish1;
            var actual = aquarium.SellFish("Ivan");

            Assert.AreEqual(expected, actual);
        }
    }
}
