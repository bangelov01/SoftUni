using NUnit.Framework;
using System;
using UnitTestingExercise;

[TestFixture]
public class DummyTests
{

    private int dummyHealth;
    private int dummyExperience;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        dummyHealth = 100;
        dummyExperience = 100;
        dummy = new Dummy(dummyHealth, dummyExperience);
    }

    [Test]
    public void When_DummyIsInitiated_DummyHealth_ShouldBeSet()
    {
        Assert.AreEqual(dummy.Health, dummyHealth);
    }

    [Test]
    public void When_Attacked_DummyShould_LoseHealth()
    {
        int attackPoints = 10;
        dummy.TakeAttack(attackPoints);

        Assert.AreEqual(dummy.Health, (dummyHealth - attackPoints));
    }

    [Test]
    public void When_Dead_DummyShould_ThrowException()
    {
        int attackPoints = 110;

        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 2; i++)
            {
                dummy.TakeAttack(attackPoints);
            }
        });
    }

    [Test]
    public void When_Dead_DummyShould_GiveExperience()
    {
        dummy = new Dummy(0, dummyExperience);

        Assert.AreEqual(dummy.GiveExperience(), dummyExperience);
    }

    [Test]
    public void When_Alive_DummyShould_NotGiveExperience()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());

        Assert.AreEqual(ex.Message, "Target is not dead.");
    }
}

