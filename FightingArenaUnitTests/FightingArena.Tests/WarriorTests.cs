using NUnit.Framework;
using System;

namespace Tests
{
    //using FightingArena;
    public class WarriorTests
    {
       [Test]
        public void ConstructorSouldInitializeProperly()
        {
            var name = "Pesho";
            var damage = 15;
            var hp = 40;

            var warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }
        [TestCase(null,15,40)]
        [TestCase(" ",15,40)]
        [TestCase("Pesho",-15,40)]
        [TestCase("Pesho",0,40)]
        [TestCase("Pesho",15,-5)]
        public void PropertiesShouldThrowArgumentException(string name,int damage,int hp)
        {

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }
        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionIfMIN_ATTACK_HpIsLowerThanHP()
        {
            var name = "Pesho";
            var damage = 15;
            var hp = 25;

            var warrior = new Warrior(name, damage, hp);

            var anotherWarrior = new Warrior("Sasho", 10, 40);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(anotherWarrior));
        }
        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionIfEnemyHpIsLowerThanMIN_ATTACK_Hp()
        {
            var name = "Pesho";
            var damage = 15;
            var hp = 25;

            var warrior = new Warrior(name, damage, hp);

            var anotherWarrior = new Warrior("Sasho", 10, 20);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(anotherWarrior));
        }
        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionIfEnemyHpIsGreaterThanMyHp()
        {
            var name = "Pesho";
            var damage = 15;
            var hp = 25;

            var warrior = new Warrior(name, damage, hp);

            var anotherWarrior = new Warrior("Sasho", 10, 66);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(anotherWarrior));
        }
        [Test]
        public void AttackMethodShouldReduceMyHp()
        {
            var name = "Pesho";
            var damage = 15;
            var hp = 50;

            var warrior = new Warrior(name, damage, hp);

            var anotherWarrior = new Warrior("Sasho", 10, 40);

            var expected = 40;
            var actual = warrior.HP - anotherWarrior.Damage;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AttackMethodShouldReduceEnemyHpToZeroIfMyDamageIsGreaterThanHisHp()
        {
            var name = "Pesho";
            var damage = 40;
            var hp = 50;

            var warrior = new Warrior(name, damage, hp);

            var anotherWarrior = new Warrior("Sasho", 10, 35);
            warrior.Attack(anotherWarrior);

            var expected = 0;
            var actual = anotherWarrior.HP;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AttackMethodShouldReduceEnemyHealth()
        {
            var name = "Pesho";
            var damage = 40;
            var hp = 50;

            var warrior = new Warrior(name, damage, hp);

            var anotherWarrior = new Warrior("Sasho", 10, 50);
            warrior.Attack(anotherWarrior);

            var expected = 10;
            var actual = anotherWarrior.HP;

            Assert.AreEqual(expected, actual);
        }
    }
}