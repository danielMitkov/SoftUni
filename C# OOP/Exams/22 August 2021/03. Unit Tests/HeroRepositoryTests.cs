using System;
using System.Linq;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void Hero_Ctor_Valid()
    {
        Hero hero = new Hero("bob",1);
        Assert.That(hero.Name,Is.EqualTo("bob"));
        Assert.That(hero.Level,Is.EqualTo(1));
    }
    [Test]
    public void Create_ThrowsFor_Null()
    {
        HeroRepository repository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(()=> repository.Create(null));
    }
    [Test]
    public void Create_ThrowsFor_Duplicate()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("bob",1);
        repository.Create(hero);
        Assert.Throws<InvalidOperationException>(() => repository.Create(hero));
    }
    [Test]
    public void Create_Valid()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("bob",1);
        string expected = "Successfully added hero bob with level 1";
        string actual = repository.Create(hero);
        Assert.That(actual,Is.EqualTo(expected));
        Assert.That(repository.Heroes.Count,Is.EqualTo(1));
        Assert.That(repository.Heroes.First(),Is.SameAs(hero));
    }
    [Test]
    public void Remove_ThrowsFor_NullOrWhiteSpace()
    {
        HeroRepository repository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(()=>repository.Remove(null));
    }
    [Test]
    public void Remove_Valid()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("bob",1);
        repository.Create(hero);
        bool isRemoved = repository.Remove("bob");
        Assert.That(isRemoved,Is.EqualTo(true));
        Assert.That(repository.Heroes.Count,Is.EqualTo(0));
    }
    [Test]
    public void GetHeroWithHighestLevel_Valid()
    {
        HeroRepository repository = new HeroRepository();
        Hero bob = new Hero("bob",1);
        Hero kim = new Hero("kim",5);
        repository.Create(bob);
        repository.Create(kim);
        Hero actualHero = repository.GetHeroWithHighestLevel();
        Assert.That(actualHero,Is.SameAs(kim));
    }
    [Test]
    public void GetHero_Valid()
    {
        HeroRepository repository = new HeroRepository();
        Hero bob = new Hero("bob",1);
        repository.Create(bob);
        Hero hero = repository.GetHero("bob");
        Assert.That(hero,Is.SameAs(bob));
    }
}