using System;
using System.Collections.Generic;
using AmazingBookstore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AmazingBookstoreTests;

[TestClass]
public class MoneyTests
{
    [TestMethod]
    public void GivenMoney_MoneysOfTheSameValueAreEqual()
    {
        var money1 = new Money(1, 0);
        var money2 = new Money(1, 0);
        
        Assert.AreEqual(money1, money2);
    }
    
    [TestMethod]
    public void GivenMoney_MoneysOfDifferentValueAreNotEqual()
    {
        var money1 = new Money(1, 0);
        var money2 = new Money(2, 0);
        
        Assert.AreNotEqual(money1, money2);
    }

    [TestMethod]
    public void GivenMoney_MoneyToStringPrintsDollarsAndCents()
    {
        var money1 = new Money(1, 1);

        Assert.AreEqual("$1.01", money1.ToString());
    }

    [TestMethod]
    public void GivenMoney_ExceptionThrownWhenCentsIsGreaterThanOrEqualToOneHundred()
    {
        Assert.ThrowsException<Exception>(() => new Money(0, 101));
    }

    [TestMethod]
    public void GivenMoney_GivenNormalizedMoneyToStringWorks()
    {
        Money actual = new Money(130);
        Assert.AreEqual("$1.30", actual.ToString());
    }

    [TestMethod]
    public void GivenMoney_GivenNormalizedMoneyToStringWorks_WhenNoDollars()
    {
        Money actual = new Money(30);
        Assert.AreEqual("$0.30", actual.ToString());
    }

    [TestMethod]
    public void WhenAddingTwoMoneysReturnsSummedMoney()
    {
        var money1 = new Money(2, 50);
        var money2 = new Money(3, 25);

        Assert.AreEqual(new Money(5, 75), money1 + money2);
    }
}
