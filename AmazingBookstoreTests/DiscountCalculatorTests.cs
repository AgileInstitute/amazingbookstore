using AmazingBookstore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AmazingBookstoreTests;

[TestClass]
public class DiscountCalculatorTests
{
    private DiscountCalculator _calculator;

    [TestInitialize]
    public void Initialize()
    {
        _calculator = new();
    }

    [TestMethod]
    public void GivenMoney_WhenGivenDiscount_ThenDiscountIsApplied()
    {
        var money = new Money(100, 0);
        var expectedNinetyDollars = new Money(90, 0);
        var actualMoneyAfterDiscount = _calculator.ApplyPercentageDiscount(money, 10);

        Assert.AreEqual(expectedNinetyDollars, actualMoneyAfterDiscount);
    }

    [TestMethod]
    public void WhenGivenZeroDiscountGetOriginalAmountBack()
    {
        var money = new Money(100, 0);
        var expectedOneHundredDollars = new Money(100, 0);
        var actualMoneyAfterZeroDiscount = _calculator.ApplyPercentageDiscount(money, 0);

        Assert.AreEqual(expectedOneHundredDollars, actualMoneyAfterZeroDiscount);
    }

    [TestMethod]
    public void WhenGivenFullDiscountItIsFree()
    {
        var money = new Money(123, 0);
        
        var expectedAmount = new Money(0, 0);
        
        var actualMoneyAfterZeroDiscount = _calculator.ApplyPercentageDiscount(money, 100);

        Assert.AreEqual(expectedAmount, actualMoneyAfterZeroDiscount);       
    }

    [TestMethod]
    public void GivenMoney_WhenGivenMoneyDiscount_ThenMoneyIsSubtracted()
    {
        var money = new Money(100, 0);
        var moneyDiscount = new Money(10, 0);

        var expectedNinetyDollars = new Money(90, 0);
        var actualMoneyAfterDiscount = _calculator.ApplyMoneyDiscount(money, moneyDiscount);

        Assert.AreEqual(expectedNinetyDollars, actualMoneyAfterDiscount);
    }
}