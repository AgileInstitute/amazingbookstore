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

    [TestMethod]
    public void CanMultiplyMoneyByLong()
    {
        var money = new Money(2, 50);
        Assert.AreEqual(new Money(5, 0), money * 2L);
    }

    [TestMethod]
    public void ItemsWithSameDataHaveSameHashCode()
    {
        var money1 = new Money(321, 32);
        var money2 = new Money(321, 32);
        
        Assert.AreEqual(money1.GetHashCode(), money2.GetHashCode());
    }

    [TestMethod]
    public void MoneyIsNotEqualToANonMoney()
    {
        var money = new Money(1, 1);
        
        Assert.IsFalse(money.Equals("$1.01"));
    }
    
    [TestMethod]
    public void MoneyIsNotEqualToNull()
    {
        var money = new Money(0, 0);
        
        Assert.IsFalse(money.Equals(null));
    }
    
    [TestMethod]
    public void MoneyCanBeSubtracted()
    {
        var money1 = new Money(1, 0);
        var money2 = new Money(0, 49);

        var expectedAmount = new Money(0, 51);
        
        Assert.AreEqual(expectedAmount, money1 - money2);
    }
    
    [TestMethod]
    public void MoneyCanBeDividedByLong()
    {
        var money = new Money(1, 0);
        var divisor = 2;

        var expectedAmount = new Money(0, 50);
        
        Assert.AreEqual(expectedAmount, money / divisor);
    }
    
    [TestMethod]
    public void MoneyCannotBeDividedByZero()
    {
        var money = new Money(1, 0);
        var divisor = 0;

        Assert.ThrowsException<DivideByZeroException>(() => money / divisor);
    }
}
