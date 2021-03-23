using NUnit.Framework;
using System;
using UnitTestingExercise;

[TestFixture]
public class AxeTests
{
    private int attack;
    private int durability;
    private int dummyHealth;
    private int dummyExp;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        attack = 5;
        durability = 10;
        dummyHealth = 100;
        dummyExp = 100;
        axe = new Axe(5, 10);
        dummy = new Dummy(dummyHealth, dummyExp);
    }

    [Test]
    public void When_AxeIsInitialized_WithAttackPoints_AttackPointsShouldBeSet()
    {
        Assert.AreEqual(axe.AttackPoints, attack);
    }

    [Test]
    public void When_AxeIsInitialized_WithDurabilityPoints_DurabilityPointssShouldBeSet()
    {
        Assert.AreEqual(axe.DurabilityPoints, durability);
    }

    [Test]
    public void When_AxeAttacks_DurabilityPoints_ShouldBeLost()
    {
        axe.Attack(dummy);

        Assert.AreEqual(axe.DurabilityPoints, --durability);
    }

    [Test]
    public void When_AxeDurability_BecomesLessOrEqualToZero_ExceptionShouldBeThrown()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i <= durability; i++)
            {
                axe.Attack(dummy);
            }
        });

        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }
}
