using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    //using FightingArena;
    public class ArenaTests
    {
       [Test]
        public void CountShouldReturnExactLenghtOfArray()
        {
            var arena = new Arena();
            arena.Enroll(new Warrior("Pesho", 15, 60));

            var expected = 1;
            var actual = arena.Count;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EnrollMethodShouldThrowInvalidOperationExceptionIfWarriorIsAlreadyEnrolled()
        {
            var arena = new Arena();
            var warrior = new Warrior("Pesho", 15, 60);
            
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }
        [Test]
        public void EnrollMethodShouldWorkProperly()
        {
            var arena = new Arena();
            var warrior = new Warrior("Pesho", 15, 60);

            arena.Enroll(warrior);

            Warrior expected = warrior;
            Warrior actual = arena.Warriors.First();

            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void FightMethodShouldThrowInvalidOperationExceptionIfOfAttackerIsNull()
        {
            var arena = new Arena();
            arena.Enroll(new Warrior("Gosho", 15, 50));

            string warrior1Name = null;
            string warrior2Name = "Gosho";

            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior1Name, warrior2Name));
        }
        [Test]
        public void FightMethodShouldThrowInvalidOperationExceptionIfDefenderIsNull()
        {
            var arena = new Arena();
            arena.Enroll(new Warrior("Gosho", 15, 50));

            string warrior1Name = null;
            string warrior2Name = "Gosho";

            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior2Name, warrior1Name));
        }
    }
}
