using NUnit.Framework;
namespace Tests
{
    //using Database;
    using System;

    public class DatabaseTests
    {
        [Test]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            var data = new int[16];
            var database = new Database(data);
            int actualCount = database.Count;
            var expected = 16;

            Assert.AreEqual(expected, actualCount);
        }
        [Test]
        public void ConstructorShouldThrowInvalidOperationExceptionIfElementsAreMoreThan16()
        {
            var array = new int[17];
            Assert.Throws<InvalidOperationException>(() => new Database(array));
        }
        [Test]
        public void AddMethodShoulddIncreaseCount()
        {
            var database = new Database();
            database.Add(1);

            int expectedCount = 1;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        public void AddMethodShouldAddOnTheNextEmptyIndex()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var database = new Database(array);
            database.Add(6);

            int expectedResult = 6;
            int actualResult = database.Fetch()[5];

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenElementsAreExceeded()
        {
            var array = new int[16];
            var database = new Database(array);

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }
        [Test]
        public void ShouldRemoveCorrectlyAndDecreaseCount()
        {
            var array = new int[] { 1, 2, 3 };
            var database = new Database(array);
            
            database.Remove();
           
            int expectedCount = 2;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void ShouldRemoveCorrectlyLastElement()
        {
            var array = new int[] { 1, 2, 3 };
            var database = new Database(array);
            
            database.Remove();
            
            int expectedValue = 2;
            int actualValue = database.Fetch()[database.Count-1];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [Test]
        public void RemoveMethodShouldThrowInvalidOperationException()
        {
            var database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
    }
}