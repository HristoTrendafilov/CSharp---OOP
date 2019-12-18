using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void HeroClassShouldInitializePropertiesCorrectly()
    {
        var name = "Pesho";
        var level = 10;
        var hero = new Hero(name, level);

        Assert.AreEqual("Pesho",hero.Name);
        Assert.AreEqual(10,hero.Level);
    }
    [Test]
    public void CreateMethodShouldThrowArgumentNullExceptionIfGivenNull()
    {
        var rep = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => rep.Create(null));
    }
    [Test]
    public void CreateMethodShouldThrowInvalidOperationExceptionIfHeroExists()
    {
        var rep = new HeroRepository();
        var hero = new Hero("Ivan", 12);
        rep.Create(hero);

        Assert.Throws<InvalidOperationException>(() => rep.Create(new Hero("Ivan", 12)));
    }
    //[Test]
    //public void CreateMethodShouldReturnCorrectString()
    //{
    //    var rep = new HeroRepository();
    //    var hero = new Hero("Ivan", 12);

    //    var expected = $"Successfully added hero {hero.Name} with level {hero.Level}";
    //    var actual = rep.Create(hero);

    //    Assert.AreEqual(expected, actual);
    //}
    [Test]
    public void RemoveMethodShouldThrowArgumentNullExceptionWhenGivenNull()
    {
        var rep = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => rep.Remove(null));
    }
    [Test]
    public void GetHeroWithHighestLevelShouldWorkCorrectly()
    {
        var rep = new HeroRepository();
        var hero = new Hero("Ivan", 12);
        var hero2 = new Hero("Pesho", 20);
        rep.Create(hero);
        rep.Create(hero2);

        var expected = hero2;
        var actual = rep.GetHeroWithHighestLevel();

        Assert.AreEqual(expected, actual);
    }
    [Test]
    public void GetHeroMethodShouldWorkCorrectly()
    {
        var rep = new HeroRepository();
        var hero = new Hero("Ivan", 12);
        rep.Create(hero);

        var expected = hero;
        var actual = rep.GetHero("Ivan");

        Assert.AreEqual(expected, actual);
    }
}