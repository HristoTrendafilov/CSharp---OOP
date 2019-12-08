using NUnit.Framework;

namespace Tests
{
    //using ExtendedDatabase;
    using System;

    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void ShouldReturnNameAndIdCorrectly()
        {
            var name = "Pesho";
            var id = 12345123525;
            
            var person = new Person(id, name);

            var expectedName = name;
            var actualName = person.UserName;

            Assert.AreEqual(expectedName, actualName);

            var expectedId = id;
            var actualId = person.Id;

            Assert.AreEqual(expectedId, actualId);
        }
        [Test]
        public void ConstructorShouldBeInitializedWithExatly16People()
        {
            Person[] people = new Person[16];
            people[0]=new Person(1,"Pesho1");
            people[1]=new Person(12,"Pesho2");
            people[2]=new Person(123,"Pesho3");
            people[3]=new Person(1234,"Pesho4");
            people[4]=new Person(12345,"Pesho5");
            people[5]=new Person(123456,"Pesho6");
            people[6]=new Person(1234567,"Pesho7");
            people[7]=new Person(12345678, "Pesho8");
            people[8]=new Person(123456789, "Pesho9");
            people[9]=new Person(12345678910, "Pesho10");
            people[10]=new Person(1234567891011, "Pesho11");
            people[11]=new Person(123456789101112, "Pesho12");
            people[12]=new Person(12345678910111213, "Pesho13");
            people[13]=new Person(1234567891011121314, "Pesho14");
            people[14]=new Person(1234567891011121315, "Pesho15");
            people[15]=new Person(1234567891011121316, "Pesho16");

            
            var extendedDatabase = new ExtendedDatabase(people);

            var actualCount = extendedDatabase.Count;
            var expectedCount = 16;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void ConstructorShouldThrowArgumentExceptionIfPeopleAreMoreThan16()
        {
            Person[] people = new Person[17];
            people[0] = new Person(1, "Pesho1");
            people[1] = new Person(12, "Pesho2");
            people[2] = new Person(123, "Pesho3");
            people[3] = new Person(1234, "Pesho4");
            people[4] = new Person(12345, "Pesho5");
            people[5] = new Person(123456, "Pesho6");
            people[6] = new Person(1234567, "Pesho7");
            people[7] = new Person(12345678, "Pesho8");
            people[8] = new Person(123456789, "Pesho9");
            people[9] = new Person(12345678910, "Pesho10");
            people[10] = new Person(1234567891011, "Pesho11");
            people[11] = new Person(123456789101112, "Pesho12");
            people[12] = new Person(12345678910111213, "Pesho13");
            people[13] = new Person(1234567891011121314, "Pesho14");
            people[14] = new Person(1234567891011121315, "Pesho15");
            people[15] = new Person(1234567891011121316, "Pesho16");
            people[16] = new Person(123456789101112132, "Pesho17");

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(people));
        }
        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfPersonExists()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1, "Pesho1");
            people[1] = new Person(12, "Pesho1");

            Assert.Throws<InvalidOperationException>(() => new ExtendedDatabase(people));
        }
        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfIdExists()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1, "Pesho1");
            people[1] = new Person(1, "Pesho2");

            Assert.Throws<InvalidOperationException>(() => new ExtendedDatabase(people));
        }
        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfWeTryToAdd17Person()
        {
            Person[] people = new Person[16];
            people[0] = new Person(1, "Pesho1");
            people[1] = new Person(12, "Pesho2");
            people[2] = new Person(123, "Pesho3");
            people[3] = new Person(1234, "Pesho4");
            people[4] = new Person(12345, "Pesho5");
            people[5] = new Person(123456, "Pesho6");
            people[6] = new Person(1234567, "Pesho7");
            people[7] = new Person(12345678, "Pesho8");
            people[8] = new Person(123456789, "Pesho9");
            people[9] = new Person(12345678910, "Pesho10");
            people[10] = new Person(1234567891011, "Pesho11");
            people[11] = new Person(123456789101112, "Pesho12");
            people[12] = new Person(12345678910111213, "Pesho13");
            people[13] = new Person(1234567891011121314, "Pesho14");
            people[14] = new Person(1234567891011121315, "Pesho15");
            people[15] = new Person(1234567891011121316, "Pesho16");

            var db = new ExtendedDatabase(people);
            
            var additionalPerson = new Person(23123132, "Shano");
            Assert.Throws<InvalidOperationException>(() => db.Add(additionalPerson));
        }
        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1, "Pesho1");
            people[1] = new Person(12, "Pesho2");
            
            var db = new ExtendedDatabase(people);
            
            db.Remove();
            
            var expectedResult = people[0];
            var actualResult = people[db.Count-1];

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionWhenArrayIs0()
        {
            Person[] people = new Person[1];
            
            people[0] = new Person(1, "Pesho1");
            var db = new ExtendedDatabase(people);

            db.Remove();
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }
        [Test]
        public void FindByUserNameShouldWorkProperly()
        {
            Person[] people = new Person[1];

            people[0] = new Person(1, "Pesho1");
            var db = new ExtendedDatabase(people);

            var expected = people[0];
            var actual = db.FindByUsername("Pesho1");

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FindByUserNameShouldThrowArgumentNullExceptionIfNameIsNullOrEmpty()
        {
            Person[] people = new Person[1];
            people[0] = new Person(1, "Pesho1");

            var db = new ExtendedDatabase(people);

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
        }
        [Test]
        public void FindByUserNameShouldThrowInvalidOperationExceptionIfNameDoesntExist()
        {
            Person[] people = new Person[1];
            people[0] = new Person(1, "Pesho1");

            var db = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Ivan"));
        }
        [Test]
        public void FindByUserIdShouldWorkProperly()
        {
            Person[] people = new Person[1];

            people[0] = new Person(1, "Pesho1");
            var db = new ExtendedDatabase(people);

            var expected = people[0];
            var actual = db.FindById(1);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ShouldThrowArgumentOutOfRangeExceptionIfPersonIdIsNegativeNumber()
        {
            Person[] people = new Person[1];
            people[0] = new Person(1, "Pesho1");

            var db = new ExtendedDatabase(people);
            
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-5));
        }
        [Test]
        public void ShouldThrowInvalidOperationExceptionIfPersonDoesNotHaveThatId()
        {
            Person[] people = new Person[1];
            people[0] = new Person(1, "Pesho1");

            var db = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => db.FindById(245));
        }
    }
}